using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Core.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core
{
    [TestFixture]
    public class PackageInstallerTests
    {
        [Test]
        public void ConstructorShould_RestorePackages_WhenObjectIsCreated()
        {
            // Test for restoring packages when the object is constructed
            //  - should test when there are dependencies in the project
            // Arrange
            var downloader = new Mock<IDownloader>();
            var project = new Mock<IProject>();

            var pack1 = new Mock<IPackage>();
            var pack2 = new Mock<IPackage>();
            var pack3 = new Mock<IPackage>();

            project.Setup(p => p.PackageRepository.GetAll()).Returns(
                new List<IPackage>() {
                    pack1.Object,
                    pack2.Object,
                    pack3.Object });

            // Act
            var installer = new PackageInstallerFake(downloader.Object, project.Object);

            // Assert
            Assert.AreEqual(3, installer.NumberOfPackages);
        }

        [Test]
        public void PerformOperationShould_InstallPackageWithoutDependencies_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Test for Install command and empty dependencies list
            //  - should call two times Download and one time Remove
            // Arrange
            var downloader = new Mock<IDownloader>();
            var package = new Mock<IPackage>();
            var project = new Mock<IProject>();

            package.Setup(p => p.Dependencies).Returns(new List<IPackage>());

            project.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloader.Object, project.Object);
            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(package.Object);

            // Assert
            downloader.Verify(d => d.Remove(It.IsAny<string>()), Times.Exactly(1));
            downloader.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void PerformOperationShould_InstallPackageWithDependenciesCountEqualsOne_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Test for Install command and at least one dependency in the dependencies list
            //  - every dependency on the chain will multiply the calls to the Download and Remove method by 2
            // Arrange
            var downloader = new Mock<IDownloader>();
            var dependencyPackage = new Mock<IPackage>();
            var package = new Mock<IPackage>();
            var project = new Mock<IProject>();

            dependencyPackage.Setup(dp => dp.Dependencies).Returns(new List<IPackage>());

            package.Setup(p => p.Dependencies).Returns(new List<IPackage>() { dependencyPackage.Object });

            project.Setup(p => p.PackageRepository.GetAll()).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloader.Object, project.Object);
            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(package.Object);

            // Assert
            downloader.Verify(d => d.Remove(It.IsAny<string>()), Times.Exactly(2));
            downloader.Verify(d => d.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
