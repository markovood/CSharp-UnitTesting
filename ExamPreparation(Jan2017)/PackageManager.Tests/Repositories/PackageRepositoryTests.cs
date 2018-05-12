using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.Repositories.FakesAndCustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories
{
    [TestFixture]
    public class PackageRepositoryTests
    {
        [Test]
        public void AddShould_ThrowArgumentNullException_WhenParameter_PackageIsNull()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var repo = new PackageRepository(logger.Object);

            IPackage package = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => repo.Add(package));
        }

        [Test]
        public void AddShould_AddPackageToPackages_WhenPackageIsValid_AndDoesNotExist()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var repo = new PackageRepositoryFake(logger.Object);

            var package = new Mock<IPackage>();

            // Act 
            repo.Add(package.Object);

            // Assert
            Assert.IsTrue(repo.Packages.Count == 1);
        }

        [Test]
        public void AddShould_LogMessage_ThatContains_AlreadyInstalled_WhenPackageExists_WithTheSameVersion()
        {
            // Arrange
            var logger = new Mock<ILogger>();

            var initialPackage = new Mock<IPackage>();
            initialPackage.Setup(p => p.Name).Returns("someName");
            initialPackage.Setup(p => p.Version.Major).Returns(1);
            initialPackage.Setup(p => p.Version.Minor).Returns(1);
            initialPackage.Setup(p => p.Version.Patch).Returns(1);
            initialPackage.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);
            var packages = new List<IPackage>() { initialPackage.Object };

            var repo = new PackageRepositoryFake(logger.Object, packages);

            var package = new Mock<IPackage>();
            package.Setup(p => p.Name).Returns("someName");
            package.Setup(p => p.Version.Major).Returns(1);
            package.Setup(p => p.Version.Minor).Returns(1);
            package.Setup(p => p.Version.Patch).Returns(1);
            package.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);

            string expectedMsg = string.Format("{0}: Package with the same version is already installed!", package.Object.Name);

            // Act 
            repo.Add(package.Object);

            // Assert
            logger.Verify(l => l.Log(expectedMsg));
        }

        [Test]
        public void AddShould_CallUpdate_WhenPackageExists_WithLowerVersion()
        {
            // Test for calling the Update method when the package exist but with lower version
            //      - DO NOT MOCK the System under test

            // Arrange
            var logger = new Mock<ILogger>();

            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("someName");
            existingPackage.Setup(p => p.Version.Major).Returns(1);
            existingPackage.Setup(p => p.Version.Minor).Returns(1);
            existingPackage.Setup(p => p.Version.Patch).Returns(1);
            existingPackage.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);
            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepositoryFake(logger.Object, packages);

            var packageToAdd = new Mock<IPackage>();
            packageToAdd.Setup(p => p.Name).Returns("someName");
            packageToAdd.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);

            // Act & Assert
            Assert.Throws<UpdateMethodCalledException>(() => repo.Add(packageToAdd.Object));
        }

        [Test]
        public void AddShould_LogTwice_WhenPackageWithHigherVersionAlreadyExists()
        {
            // Test for package with higher version already exist
            // Arrange
            var logger = new Mock<ILogger>();

            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("someName");
            existingPackage.Setup(p => p.Version.Major).Returns(1);
            existingPackage.Setup(p => p.Version.Minor).Returns(1);
            existingPackage.Setup(p => p.Version.Patch).Returns(1);
            existingPackage.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);
            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepositoryFake(logger.Object, packages);

            var packageToAdd = new Mock<IPackage>();
            packageToAdd.Setup(p => p.Name).Returns("someName");
            packageToAdd.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            // Act
            repo.Add(packageToAdd.Object);

            // Assert
            logger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void DeleteShould_ThrowArgumentNullException_WhenInvalidPackageIsPassed()
        {
            // Arrange
            var logger = new Mock<ILogger>();
            var packages = new List<IPackage>();

            var repo = new PackageRepositoryFake(logger.Object, packages);

            IPackage packageToDelete = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Delete(packageToDelete));
        }

        [Test]
        public void DeleteShoul_ThrowArgumentNullException_WhenPackageIsNotFound()
        {
            // Test for package not found
            // Arrange
            var logger = new Mock<ILogger>();
            var packages = new List<IPackage>();

            var repo = new PackageRepository(logger.Object, packages);

            var packageToDelete = new Mock<IPackage>();
            packageToDelete.Setup(p => p.Name).Returns("SomeName");
            packageToDelete.Setup(p => p.Version.Major).Returns(1);
            packageToDelete.Setup(p => p.Version.Minor).Returns(2);
            packageToDelete.Setup(p => p.Version.Patch).Returns(3);
            packageToDelete.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);

            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Delete(packageToDelete.Object));
        }

        [Test]
        public void DeleteShould_LogExactlyThreeTimes_WhenPackageIsFoundButIsADependencyAndCannotBeRemoved()
        {
            // test for package found but is a dependency of other projects and cannot be removed
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Equals(It.IsAny<IPackage>())).Returns(true);

            var dependencyPackage = new Mock<IPackage>();
            dependencyPackage.Setup(p => p.Equals(It.IsAny<IPackage>())).Returns(true);

            existingPackage.Setup(p => p.Dependencies).Returns(new List<IPackage>() { dependencyPackage.Object });

            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);

            var packageToDelete = new Mock<IPackage>();

            // Act
            repo.Delete(packageToDelete.Object);

            // Assert
            logger.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void DeleteShould_ReturnThePackageDeleted()
        {
            // test for returning package deleted
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Dependencies).Returns(new List<IPackage>());
            existingPackage.Setup(p => p.Equals(It.IsAny<IPackage>())).Returns(true);

            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);

            var packageToDelete = new Mock<IPackage>();
            packageToDelete.Setup(p => p.Name).Returns("SomeName");
            packageToDelete.Setup(p => p.Version.Major).Returns(1);
            packageToDelete.Setup(p => p.Version.Minor).Returns(2);
            packageToDelete.Setup(p => p.Version.Patch).Returns(3);
            packageToDelete.Setup(p => p.Version.VersionType).Returns(VersionType.alpha);

            // Act
            var deletedPackage = repo.Delete(packageToDelete.Object);

            // Assert
            Assert.AreEqual(packageToDelete.Object, deletedPackage);
        }

        [Test]
        public void UpdateShould_ThrowArgumentNullException_WhenNullPackageIsPassed()
        {
            // test for valid and invalid value package
            // Arrange
            var logger = new Mock<ILogger>();
            var packages = new List<IPackage>();

            var repo = new PackageRepository(logger.Object, packages);
            IPackage updatePackage = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Update(updatePackage));
        }

        [Test]
        public void UpdateShould_ThrowArgumentNullException_WhenPackageIsNotFound()
        {
            // test for package not found
            // Arrange
            var logger = new Mock<ILogger>();
            var packages = new List<IPackage>();

            var repo = new PackageRepository(logger.Object, packages);
            var updatePackage = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Update(updatePackage.Object));
        }

        [Test]
        public void UpdateShould_UpdateSuccessfully_WhenPackageIsFound_WithLowerVersion()
        {
            // test for successfully updated package when there is package found with lower version
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("SomeName");

            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);
            var updatePackage = new Mock<IPackage>();
            updatePackage.Setup(p => p.Name).Returns("SomeName");
            updatePackage.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(1);
            
            // Act & Assert
            Assert.IsTrue(repo.Update(updatePackage.Object));
        }

        [Test]
        public void UpdateShould_ThrowArgumentException_WhenPackageFoundIsWithHigherVersion()
        {
            // Test for found package with higher version
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("SomeName");

            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);
            var updatePackage = new Mock<IPackage>();
            updatePackage.Setup(p => p.Name).Returns("SomeName");
            updatePackage.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repo.Update(updatePackage.Object));
        }

        [Test]
        public void UpdateShould_ReturnFalse_WhenPackageFoundIsWithTheSameVersion()
        {
            // Test for found package with the same version
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("SomeName");

            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);
            var updatePackage = new Mock<IPackage>();
            updatePackage.Setup(p => p.Name).Returns("SomeName");
            updatePackage.Setup(p => p.CompareTo(It.IsAny<IPackage>())).Returns(0);

            // Act & Assert
            Assert.IsFalse(repo.Update(updatePackage.Object));
        }

        [Test]
        public void GetAllShould_ReturnAsParameterEmptyCollection_WhenRepositoryPassedWithNoCollection()
        {
            // Test for repository with no passed collection to return as parameter empty collection
            // Arrange
            var logger = new Mock<ILogger>();

            var repo = new PackageRepository(logger.Object);

            // Act
            var collection = repo.GetAll();

            // Assert
            Assert.AreEqual(0, collection.Count());
        }

        [Test]
        public void GetAllShould_ReturnCollectionWithEqualNumberOfElements()
        {
            // Test for repository with passed collection as parameter to return collection with equal number of elements
            // Arrange
            var logger = new Mock<ILogger>();
            var existingPackage = new Mock<IPackage>();
            existingPackage.Setup(p => p.Name).Returns("Test");
            var packages = new List<IPackage>() { existingPackage.Object };

            var repo = new PackageRepository(logger.Object, packages);

            // Act
            var collectionReturned = repo.GetAll();

            // Assert
            Assert.AreEqual(packages.Count, collectionReturned.Count());
        }
    }
}
