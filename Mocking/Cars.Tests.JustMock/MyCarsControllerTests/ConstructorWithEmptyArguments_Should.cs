using Cars.Tests.JustMock.MyMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cars.Tests.JustMock.MyCarsControllerTests
{
    [TestClass]
    public class ConstructorWithEmptyArguments_Should
    {
        [TestMethod]
        public void InitializeCarsDataPrivateField()
        {
            // Arrange & Act
            var controller = new CarsControllerMock();

            // Assert
            Assert.IsNotNull(controller.CarsData, "Constructor did not initialize carsData field!");
        }
    }
}