using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class PackageVersionTests
    {
        [Test]
        public void ConstructorShould_SetTheAppropriatePassedValues()
        {
            // Arrange
            int expectedMajor = 100;
            int expectedMinor = 10;
            int expectedPatch = 1;
            var expectedVersionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(expectedMajor, expectedMinor, expectedPatch, expectedVersionType);

            // Assert
            Assert.AreEqual(expectedMajor, packageVersion.Major, "major");
            Assert.AreEqual(expectedMinor, packageVersion.Minor, "minor");
            Assert.AreEqual(expectedPatch, packageVersion.Patch, "patch");
            Assert.AreEqual(expectedVersionType, packageVersion.VersionType, "versionType");
        }

        [Test]
        public void MajorPropertyShould_ThrowArgumentException_IfValuePassedIsInvalid()
        {
            // Arrange
            int invalidMajor = -1;
            int minor = 10;
            int patch = 1;
            var versionType = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(invalidMajor, minor, patch, versionType));
        }

        [Test]
        public void MajorPropertyShould_SetValue_IfValuePassedIsValid()
        {
            // Arrange
            int validMajor = 100;
            int minor = 10;
            int patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(validMajor, minor, patch, versionType);

            // Assert
            Assert.AreEqual(validMajor, packageVersion.Major);
        }
        
        [Test]
        public void MinorPropertyShould_ThrowArgumentException_IfValuePassedIsInvalid()
        {
            // Arrange
            int major = 100;
            int invalidMinor = -1;
            int patch = 1;
            var versionType = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(major, invalidMinor, patch, versionType));
        }

        [Test]
        public void MinorPropertyShould_SetValue_IfValuePassedIsValid()
        {
            // Arrange
            int major = 100;
            int validMinor = 10;
            int patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, validMinor, patch, versionType);

            // Assert
            Assert.AreEqual(validMinor, packageVersion.Minor);
        }

        [Test]
        public void PatchPropertyShould_ThrowArgumentException_IfValuePassedIsInvalid()
        {
            // Arrange
            int major = 100;
            int minor = 10;
            int invalidPatch = -1;
            var versionType = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(major, minor, invalidPatch, versionType));
        }

        [Test]
        public void PatchPropertyShould_SetValue_IfValuePassedIsValid()
        {
            // Arrange
            int major = 100;
            int minor = 10;
            int validPatch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, validPatch, versionType);

            // Assert
            Assert.AreEqual(validPatch, packageVersion.Patch);
        }

        [Test]
        public void VersionTypePropertyShould_ThrowArgumentException_IfValuePassedIsUndefined()
        {
            // Arrange
            int major = 100;
            int minor = 10;
            int patch = 1;
            VersionType versionType = (VersionType)4;

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ValueTypePropertyShould_SetValue_IfValuePassedIsDefined()
        {
            // Arrange
            int major = 100;
            int minor = 10;
            int patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(versionType, packageVersion.VersionType);
        }
    }
}
