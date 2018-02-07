using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.Repositories.Fakes;
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
        public void TODOTestMethod()
        {
            Assert.Fail();
            // Test for calling the Update method when the package exist but with lower version
            //      - DO NOT MOCK the System under test
            // Test for package with higher version already exist
            // Test for package with lower version already exist
        }
    }
}
