using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void PayShouldThrow_NullReferenceException_IfTheObjectPassedIsNull()
        {
            // Arrange
            int id = 0;
            string nickName = string.Empty;

            var unit = new Unit(id, nickName);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void PayShould_DecreaseTheOwnerAmountOfResources_ByTheAmountOfTheCost()
        {
            // Arrange
            int id = 0;
            string nickName = string.Empty;
            
            var owner = new Unit(id, nickName);

            var initialResource = new Mock<IResources>();
            initialResource.Setup(c => c.BronzeCoins).Returns(100U);
            initialResource.Setup(c => c.GoldCoins).Returns(100U);
            initialResource.Setup(c => c.SilverCoins).Returns(100U);

            owner.Resources.Add(initialResource.Object);

            var cost = new Mock<IResources>();
            cost.Setup(c => c.BronzeCoins).Returns(10U);
            cost.Setup(c => c.GoldCoins).Returns(15U);
            cost.Setup(c => c.SilverCoins).Returns(20U);
            
            var expectedBronzeCoins = initialResource.Object.BronzeCoins - cost.Object.BronzeCoins;
            var expectedGoldCoins = initialResource.Object.GoldCoins - cost.Object.GoldCoins;
            var expectedSilverCoins = initialResource.Object.SilverCoins - cost.Object.SilverCoins;

            // Act
            owner.Pay(cost.Object);
            var actualBronzeCoins = owner.Resources.BronzeCoins;
            var actualGoldCoins = owner.Resources.GoldCoins;
            var actualSilverCoins = owner.Resources.SilverCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins, "bronzeCoins");
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins, "goldCoins");
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins, "silverCoins");
        }

        [Test]
        public void PayShould_ReturnResourceObject_WithTheAmountOfResourcesInTheCostObject()
        {
            // Arrange
            int id = 0;
            string nickName = string.Empty;

            var owner = new Unit(id, nickName);

            var cost = new Mock<IResources>();
            cost.Setup(c => c.BronzeCoins).Returns(10U);
            cost.Setup(c => c.GoldCoins).Returns(15U);
            cost.Setup(c => c.SilverCoins).Returns(20U);

            // Act
            var payedResource = owner.Pay(cost.Object);

            // Assert
            Assert.IsInstanceOf<IResources>(payedResource, "payedResource");
            Assert.AreEqual(cost.Object.BronzeCoins, payedResource.BronzeCoins, "bronzeCoins");
            Assert.AreEqual(cost.Object.GoldCoins, payedResource.GoldCoins, "goldCoins");
            Assert.AreEqual(cost.Object.SilverCoins, payedResource.SilverCoins, "silverCoins");
        }
    }
}
