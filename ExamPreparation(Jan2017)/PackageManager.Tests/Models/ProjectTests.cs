using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void ConstructorShould_SetTheApropriatePassedValues()
        {
            // Arrange
            string expectedName = "SomeProject";
            string expectedLocation = "SomeLocation";

            // Act
            var project = new Project(expectedName, expectedLocation);

            // Assert
            Assert.AreEqual(expectedName, project.Name, "name");
            Assert.AreEqual(expectedLocation, project.Location, "location");
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenParameterNameIsNull()
        {
            // Arrange
            string name = null;
            string location = "SomeLocation";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Project(name, location));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenParameterLocationIsNull()
        {
            // Arrange
            string name = "SomeName";
            string location = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new Project(name, location));
        }

        [Test]
        public void ConstructorShould_SetTheApropriatePassedValues_AndSet_PackageRepository_ToDefaultValue_WhenParameter_Packages_IsNotPassed()
        {
            // Arrange
            string expectedName = "SomeProject";
            string expectedLocation = "SomeLocation";

            // Act
            var project = new Project(expectedName, expectedLocation);

            // Assert
            Assert.IsNotNull(project.PackageRepository);
        }

        [Test]
        public void ConstructorShould_SetTheApropriatePassedValues_AndSet_PackageRepository_ToTheValue_WhenParameter_Packages_IsPassed()
        {
            // Arrange
            string expectedName = "SomeProject";
            string expectedLocation = "SomeLocation";
            var packages = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(expectedName, expectedLocation, packages.Object);

            // Assert
            Assert.AreEqual(packages.Object, project.PackageRepository);
        }

        [Test]
        public void NamePropertyShould_BeSetCorrectly_WhenValidValueIsPassed()
        {
            // Test if Name is set correctly
            // Test if Location is set correctly
            // Arrange
            string name = "SomeName";
            string location = "SomeLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreEqual(name, project.Name);
        }

        [Test]
        public void LocationPropertyShould_BeSetCorrectly_WhenValidValueIsPassed()
        {
            // Test if Name is set correctly
            // Test if Location is set correctly
            // Arrange
            string name = "SomeName";
            string location = "SomeLocation";

            // Act
            var project = new Project(name, location);

            // Assert
            Assert.AreEqual(location, project.Location);
        }
    }
}
