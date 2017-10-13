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
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResourcesShouldReturn_NewlyCreatedResourcesObject_WithCorrectlySetUpProperties_NoMatterWhatTheOrderOfParametersIs(string command)
        {
            // Arrange 
            const uint expectedBronzeCoins = 40;
            const uint expectedSilverCoins = 30;
            const uint expectedGoldCoins = 20;
            var factory = new ResourcesFactory();

            // Act
            var resourcesObj = factory.GetResources(command);

            // Assert
            Assert.AreEqual(expectedBronzeCoins, resourcesObj.BronzeCoins, "bronzeCoins");
            Assert.AreEqual(expectedSilverCoins, resourcesObj.SilverCoins, "SilverCoins");
            Assert.AreEqual(expectedGoldCoins, resourcesObj.GoldCoins, "goldCoins");
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResourcesShouldThrow_InvalidOperationException_WhenTheInputStringRepresentsInvalidCommand(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResourcesShouldThrow_OverflowException_WhenTheInputStringCommandIsInTheCorrectFormat_ButAnyOfTheValuesThatRepresentTheResourceAmountIsLargerThanUintMaxValue(string command)
        {
            // Arrange 
            var factory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
