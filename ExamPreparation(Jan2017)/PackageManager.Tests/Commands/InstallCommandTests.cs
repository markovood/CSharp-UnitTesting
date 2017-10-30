using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands
{
    [TestFixture]
    public class InstallCommandTests
    {
        [Test]
        public void ConstructorShould_SetTheAppropriatePassedValues()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            // Act
            var command = new InstallCommandFake(installer.Object, package.Object);

            // Assert
            Assert.IsNotNull(command.Installer, "installer");
            Assert.IsNotNull(command.Package, "package");
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenArgument_Installer_IsNull()
        {
            // Arrange
            IInstaller<IPackage> installer = null;
            var expectedPackage = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new InstallCommand(installer, expectedPackage.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenArgument_Package_IsNull()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            IPackage package = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new InstallCommand(installer.Object, package));
        }

        [Test]
        public void ConstructorShould_SetCorectValueFor_Installer_Field()
        {
            // Arrange
            var expectedInstaller = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            // Act
            var command = new InstallCommandFake(expectedInstaller.Object, package.Object);

            // Assert
            Assert.AreEqual(expectedInstaller.Object, command.Installer);
        }

        [Test]
        public void ConstructorShould_SetCorectValueFor_Package_Field()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var expectedPackage = new Mock<IPackage>();

            // Act
            var command = new InstallCommandFake(installer.Object, expectedPackage.Object);

            // Assert
            Assert.AreEqual(expectedPackage.Object, command.Package);
        }

        [Test]
        public void ConstructorShould_SetCorrectValueFor_Operation_OfTheInstaller()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            var expectedOperation = InstallerOperation.Install;

            // Act
            var command = new InstallCommandFake(installer.Object, package.Object);

            // Assert
            Assert.AreEqual(expectedOperation, command.Installer.Operation);
        }

        [Test]
        public void ExecuteShould_Call_PerformOperation_FromInstaller()
        {
            // Arrange
            var installer = new Mock<IInstaller<IPackage>>();
            var package = new Mock<IPackage>();

            var command = new InstallCommand(installer.Object, package.Object);

            // Act
            command.Execute();

            // Assert
            installer.Verify(x => x.PerformOperation(It.IsAny<IPackage>()));
        }

    }
}
