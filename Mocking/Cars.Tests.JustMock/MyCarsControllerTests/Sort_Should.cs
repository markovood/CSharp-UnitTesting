using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cars.Contracts;
using Cars.Controllers;
using System;

namespace Cars.Tests.JustMock.MyCarsControllerTests
{
    [TestClass]
    public class Sort_Should
    {
        [TestMethod]
        public void CallSortByMakeMethod_WhenMakeStringIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act
            controller.Sort("make");

            // Assert
            repositoryMock.Verify(r => r.SortedByMake());
        }

        [TestMethod]
        public void CallSortByYearMethod_WhenYearStringIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act
            controller.Sort("year");

            // Assert
            repositoryMock.Verify(r => r.SortedByYear());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowException_WhenParameterStringDoesNotExist()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act & Assert
            controller.Sort("some invalid parameter");
        }

        [TestMethod]
        public void ReturnView_WhenValidParameterIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act
            var result = controller.Sort("year");

            // Assert
            Assert.IsInstanceOfType(result, typeof(IView));
        }
    }
}
