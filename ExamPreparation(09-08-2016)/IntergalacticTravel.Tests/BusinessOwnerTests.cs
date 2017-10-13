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
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfitsShould_IncreaseTheOwnerResources_ByTheTotalAmountOfResourcesGeneratedFromTheTeleportStations_ThatAreInHisPossession()
        {
            // Arrange
            const uint expectedBronzeCoins = 1U;
            const uint expectedGoldCoins = 15U;
            const uint expectedSilverCoins = 10U;
            int id = 0;
            string nickName = string.Empty;


            var teleportStationsList = new List<ITeleportStation>();
            var teleportStationMock = new Mock<ITeleportStation>();

            var resourceMock = new Mock<IResources>();
            resourceMock.Setup(x => x.BronzeCoins).Returns(expectedBronzeCoins);
            resourceMock.Setup(x => x.GoldCoins).Returns(expectedGoldCoins);
            resourceMock.Setup(x => x.SilverCoins).Returns(expectedSilverCoins);

            teleportStationsList.Add(teleportStationMock.Object);

            var owner = new BusinessOwner(id, nickName, teleportStationsList);

            teleportStationMock.Setup(ts => ts.PayProfits(owner)).Returns(resourceMock.Object);
            
            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(expectedBronzeCoins, owner.Resources.BronzeCoins, "bronzeCoins");
            Assert.AreEqual(expectedGoldCoins, owner.Resources.GoldCoins, "goldCoins");
            Assert.AreEqual(expectedSilverCoins, owner.Resources.SilverCoins, "silverCoins");
        }
    }
}
