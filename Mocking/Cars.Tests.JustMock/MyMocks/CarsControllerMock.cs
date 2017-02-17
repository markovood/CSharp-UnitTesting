using Cars.Controllers;
using Cars.Contracts;

namespace Cars.Tests.JustMock.MyMocks
{
    internal class CarsControllerMock : CarsController
    {
        public ICarsRepository CarsData
        {
            get { return this.carsData; }
        }
    }
}
