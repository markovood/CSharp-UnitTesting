using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {
        [Test]
        public void GetResourcesShouldReturnNewlyCreatedResourcesObjectWithCorrectlySetUpProperties()
        {
            // Arrange 
            const string command = "";
            var factory = new ResourcesFactory();

            // Act
            var resourcesObj = factory.GetResources(command);

            // Assert

        }
    }
}
