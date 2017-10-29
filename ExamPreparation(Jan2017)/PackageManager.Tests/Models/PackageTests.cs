using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void ConstructorShould_SetTheAppropriatePassedValues()
        {
            // Arrange
            string expectedName = "SomeName";
            var expectedVersion = new Mock<IVersion>();

            // Act
            var package = new Package(expectedName, expectedVersion.Object);

            // Assert
            Assert.AreEqual(expectedName, package.Name, "name");
            Assert.AreEqual(expectedVersion.Object, package.Version, "version");
        }

        [Test]
        public void ConstructorShould_SetTheAppropriatePassedValue_AndSetThe_Dependencies_PropertyToTheDefaultValue_When_DependenciesPropertyIsNotPassed()
        {
            // Arrange
            string expectedName = "SomeName";
            var expectedVersion = new Mock<IVersion>();

            // Act
            var package = new Package(expectedName, expectedVersion.Object);

            // Assert
            Assert.IsNotNull(package.Dependencies);
        }

        [Test]
        public void ConstructorShould_SetTheAppropriatePassedValue_AndSetThe_Dependencies_PropertyToTheValuePassed()
        {
            // Arrange
            string expectedName = "SomeName";
            var expectedVersion = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(expectedName, expectedVersion.Object, dependencies.Object);

            // Assert
            Assert.AreEqual(dependencies.Object, package.Dependencies);
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_When_Parameter_NameIsNull()
        {
            // Arrange
            string name = null;
            var version = new Mock<IVersion>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Package(name, version.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_When_Parameter_VersionIsNull()
        {
            // Arrange
            string name = "SomeName";
            IVersion version = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Package(name, version));
        }

        [Test]
        public void NamePropertyShould_BeSetCorrectly_WhenValidParameterNameIsPassed()
        {
            // Arrange
            string expectedName = "SomeName";
            var version = new Mock<IVersion>();

            // Act
            var package = new Package(expectedName, version.Object);

            // Assert
            Assert.AreEqual(expectedName, package.Name);
        }

        [Test]
        public void VersionPropertyShould_BeSetCorrectly_WhenValidParameterVersionIsPassed()
        {
            // Arrange
            string name = "SomeName";
            var expectedVersion = new Mock<IVersion>();

            // Act
            var package = new Package(name, expectedVersion.Object);

            // Assert
            Assert.AreEqual(expectedVersion.Object, package.Version);
        }

        [Test]
        public void UrlPropertyShould_BeSetCorrectly()
        {
            // Arrange
            string name = "SomeName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(1);
            version.Setup(v => v.Minor).Returns(2);
            version.Setup(v => v.Patch).Returns(3);
            version.Setup(v => v.VersionType).Returns(VersionType.beta);

            var expectedUrl = string.Format(
                "{0}.{1}.{2}-{3}",
                version.Object.Major,
                version.Object.Minor,
                version.Object.Patch,
                version.Object.VersionType);

            // Act
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }

        [Test]
        public void CompareToShould_ThrowArgumentNullException_When_Other_ParameterValueIsNull()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();

            var package = new Package(name, version.Object);
            IPackage other = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => package.CompareTo(other));
        }

        [Test]
        public void CompareToShould_ReturnInt_WhenValidParameter_Other_IsPassed()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(It.IsAny<int>());
            version.Setup(v => v.Minor).Returns(It.IsAny<int>());
            version.Setup(v => v.Patch).Returns(It.IsAny<int>());
            version.Setup(v => v.VersionType).Returns(It.IsAny<VersionType>());

            var package = new Package(name, version.Object);
            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns(name);
            other.Setup(p => p.Version.Major).Returns(It.IsAny<int>());
            other.Setup(p => p.Version.Minor).Returns(It.IsAny<int>());
            other.Setup(p => p.Version.Patch).Returns(It.IsAny<int>());
            other.Setup(p => p.Version.VersionType).Returns(It.IsAny<VersionType>());

            // Act
            var result = package.CompareTo(other.Object);

            // Assert
            Assert.IsAssignableFrom<int>(result);
        }

        [Test]
        public void CompareToShould_ThrowArgumentException_WhenThePackagePassedIsNotWithTheSameName()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();

            var package = new Package(name, version.Object);
            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns("otherName");

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => package.CompareTo(other.Object));
        }

        [Test]
        public void CompareToShould_ReturnMinusOne_WhenParameter_Other_IsHigherVersion()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(1);
            version.Setup(v => v.Minor).Returns(0);
            version.Setup(v => v.Patch).Returns(1);
            version.Setup(v => v.VersionType).Returns(VersionType.alpha);

            var package = new Package(name, version.Object);
            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns(name);
            other.Setup(p => p.Version.Major).Returns(1);
            other.Setup(p => p.Version.Minor).Returns(1);
            other.Setup(p => p.Version.Patch).Returns(1);
            other.Setup(p => p.Version.VersionType).Returns(VersionType.beta);

            // Act
            var result = package.CompareTo(other.Object);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareToShould_ReturnOne_WhenParameter_Other_IsLowerVersion()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(2);
            version.Setup(v => v.Minor).Returns(0);
            version.Setup(v => v.Patch).Returns(1);
            version.Setup(v => v.VersionType).Returns(VersionType.beta);

            var package = new Package(name, version.Object);
            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns(name);
            other.Setup(p => p.Version.Major).Returns(1);
            other.Setup(p => p.Version.Minor).Returns(1);
            other.Setup(p => p.Version.Patch).Returns(1);
            other.Setup(p => p.Version.VersionType).Returns(VersionType.beta);

            // Act
            var result = package.CompareTo(other.Object);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareToShould_ReturnZero_WhenParameter_Other_IsTheSameVersion()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(2);
            version.Setup(v => v.Minor).Returns(0);
            version.Setup(v => v.Patch).Returns(1);
            version.Setup(v => v.VersionType).Returns(VersionType.beta);

            var package = new Package(name, version.Object);
            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns(name);
            other.Setup(p => p.Version.Major).Returns(2);
            other.Setup(p => p.Version.Minor).Returns(0);
            other.Setup(p => p.Version.Patch).Returns(1);
            other.Setup(p => p.Version.VersionType).Returns(VersionType.beta);

            // Act
            var result = package.CompareTo(other.Object);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void EqualsShould_ThrowArgumentNullException_WhenParameter_Other_IsNull()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            var package = new Package(name, version.Object);

            IPackage other = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => package.Equals(other));
        }

        [Test]
        public void EqualsShould_ReturnBoolValue_WhenParameter_Other_IsValid()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            var package = new Package(name, version.Object);

            var other = new Mock<IPackage>();

            // Act 
            var result = package.Equals(other.Object);

            // Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Test]
        public void EqualsShould_ThrowArgumentException_WhenParameter_Other_IsNot_IPackageType()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            var package = new Package(name, version.Object);

            var other = new Mock<IVersion>();

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => package.Equals(other.Object));
        }

        [Test]
        public void EqualsShould_ReturnTrue_WhenParameter_Other_IsEqual()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(1);
            version.Setup(v => v.Minor).Returns(2);
            version.Setup(v => v.Patch).Returns(3);
            version.Setup(v => v.VersionType).Returns(VersionType.final);

            var package = new Package(name, version.Object);

            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns(name);
            other.Setup(p => p.Version.Major).Returns(1);
            other.Setup(p => p.Version.Minor).Returns(2);
            other.Setup(p => p.Version.Patch).Returns(3);
            other.Setup(p => p.Version.VersionType).Returns(VersionType.final);

            // Act 
            var result = package.Equals(other.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsShould_ReturnFalse_WhenParameter_Other_IsNotEqual()
        {
            // Arrange
            string name = "someName";
            var version = new Mock<IVersion>();
            version.Setup(v => v.Major).Returns(1);
            version.Setup(v => v.Minor).Returns(2);
            version.Setup(v => v.Patch).Returns(3);
            version.Setup(v => v.VersionType).Returns(VersionType.final);

            var package = new Package(name, version.Object);

            var other = new Mock<IPackage>();
            other.Setup(p => p.Name).Returns("otherName");
            other.Setup(p => p.Version.Major).Returns(3);
            other.Setup(p => p.Version.Minor).Returns(2);
            other.Setup(p => p.Version.Patch).Returns(1);
            other.Setup(p => p.Version.VersionType).Returns(VersionType.final);

            // Act 
            var result = package.Equals(other.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
