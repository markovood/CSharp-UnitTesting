using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cars.Contracts;
using Cars.Models;
using Cars.Controllers;

namespace Cars.Tests.JustMock.MyCarsControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExeption_WhenInvalidIdIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            repositoryMock.Setup(c => c.GetById(It.IsAny<int>())).Returns((Car)null);

            // Act
            controller.Details(It.IsAny<int>());
        }
    }
}
