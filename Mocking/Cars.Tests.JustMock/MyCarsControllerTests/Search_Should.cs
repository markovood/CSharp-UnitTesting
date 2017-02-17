using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cars.Contracts;
using Cars.Controllers;
using System.Collections.Generic;
using Cars.Models;

namespace Cars.Tests.JustMock.MyCarsControllerTests
{
    [TestClass]
    public class Search_Should
    {
        [TestMethod]
        public void CallSearch_WhenConditionIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act
            controller.Search(It.IsAny<string>());

            // Assert
            repositoryMock.Verify(r => r.Search(It.IsAny<string>()));
        }

        [TestMethod]
        public void ReturnView_WhenConditionIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<ICarsRepository>();
            var controller = new CarsController(repositoryMock.Object);

            // Act
            var result = controller.Search(It.IsAny<string>());

            // Assert
            Assert.IsInstanceOfType(result, typeof(IView));
        }
    }
}
