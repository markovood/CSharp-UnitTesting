using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Fakes;
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
    public class TeleportStationTests
    {
        [Test]
        public void ConstructorShould_SetUpAllProvidedFields_WhenNewTeleportStationIsCreated_WithValidParametersPassed()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new List<IPath>();
            var location = new Mock<ILocation>();

            var expectedOwner = owner.Object;
            var expectedMap = map;
            var expectedLocation = location.Object;

            // Act
            var teleportStation = new TeleportStationFake(owner.Object, map, location.Object);

            var actualOwner = teleportStation.Owner;
            var actualMap = teleportStation.GalacticMap;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreEqual(expectedOwner, actualOwner, "owner");
            Assert.AreEqual(expectedMap, actualMap, "map");
            Assert.AreEqual(expectedLocation, actualLocation, "location");
        }

        [Test]
        public void TeleportUnitShouldThrow_ArgumentNullException_WithMessageThatContainsString_unitToTeleport_WhenUnitToTeleportISNull()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var targetLocation = new Mock<ILocation>();
            var teleportStation = new TeleportStation(owner.Object, map.Object, location.Object);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, targetLocation.Object));
            Assert.IsTrue(ex.Message.Contains("unitToTeleport"), "Exception thrown does not contain 'unitToTeleport' in the message!");
        }

        [Test]
        public void TeleportUnitShouldThrow_ArgumentNullException_WithMessageThatContainsString_destination_WhenILocationDestinationISNull()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var teleportStation = new TeleportStation(owner.Object, map.Object, location.Object);
            var unitToTeleport = new Mock<IUnit>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(unitToTeleport.Object, null));
            Assert.IsTrue(ex.Message.Contains("destination"), "Exception thrown does not contain 'destination' in the message!");
        }

        [Test]
        public void TeleportUnitShouldThrow_TeleportOutOfRangeException_WhenUnitIsTryingToUseTheTeleportStationFromADistantLocation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("Earth");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("MilkyWay");

            var teleportStation = new TeleportStation(owner.Object, map.Object, location.Object);

            var remoteLocation = new Mock<ILocation>();
            remoteLocation.Setup(l => l.Planet.Name).Returns("IzmislenaPlaneta");
            remoteLocation.Setup(l => l.Planet.Galaxy.Name).Returns("S2");

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(unit => unit.CurrentLocation).Returns(remoteLocation.Object);

            var targetLocation = new Mock<ILocation>();

            string expectedMsg = "unitToTeleport.CurrentLocation";

            // Act & Assert
            var ex = Assert.Throws<TeleportOutOfRangeException>(
                () => teleportStation.TeleportUnit(
                    unitToTeleport.Object,
                    targetLocation.Object));
            StringAssert.Contains(expectedMsg, ex.Message, "Expected string is not found within the actual one!");
        }

        [Test]
        public void TeleportUnitShouldThrow_InvalidTeleportationLocationException_WhenTryingToTeleportUnitToLocationAlreadyTakenByAnotherUnit()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var map = new List<IPath>();
            var planetUnit = new Mock<IUnit>();
            planetUnit.Setup(u => u.Resources.BronzeCoins).Returns(100U);
            planetUnit.Setup(u => u.Resources.GoldCoins).Returns(100U);
            planetUnit.Setup(u => u.Resources.SilverCoins).Returns(100U);
            planetUnit.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(1.1);
            planetUnit.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(1.1);
            planetUnit.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            planetUnit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            var planetUnits = new List<IUnit>() { planetUnit.Object };

            var pathLocation = new Mock<ILocation>();
            pathLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            pathLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            pathLocation.Setup(l => l.Planet.Units).Returns(planetUnits);

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation).Returns(pathLocation.Object);

            map.Add(path.Object);

            var location = new Mock<ILocation>();
            location.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            location.Setup(l => l.Coordinates.Longtitude).Returns(1.1);
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);
            

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(1.1);
            unitToTeleport.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(1.1);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            string expectedMsg = "units will overlap";

            // Act & Assert
            var ex = Assert.Throws<InvalidTeleportationLocationException>(
                () => teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object));
            StringAssert.Contains(
                expectedMsg, 
                ex.Message,
                "Expected string is not found within the actual message!");
        }

        [Test]
        public void TeleportUnitShouldThrow_LocationNotFoundException_WhenTryingToTeleportUnitToGalaxyWhichIsNotInTheLocationListOfTheTeleportStation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new List<IPath>();
            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            map.Add(path.Object);

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyZ");

            string expected = "Galaxy";

            // Act & Assert
            var ex = Assert.Throws<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object));
            StringAssert.Contains(
                expected,
                ex.Message,
                "Expected string is not found within the actual message!");
        }

        [Test]
        public void TeleportUnitShouldThrow_LocationNotFoundException_WhenTryingToTeleportUnitToPlanetWhichIsNotInTheLocationsListOfTheTeleportStation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            var map = new List<IPath>();
            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetZ");
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            map.Add(path.Object);

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            string expected = "Planet";

            // Act & Assert
            var ex = Assert.Throws<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object));
            StringAssert.Contains(
                expected,
                ex.Message,
                "Expected string is not found within the actual message!");
        }

        [Test]
        public void TeleportUnitShouldThrow_InsufficientResourcesException_WhenTryingToTeleportUnitToGivenLocation_ButTheServiceCostsMoreThanTheUnitsCurrentAvailableResources()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unit = new Mock<IUnit>();
            unit.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unit.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);
            unit.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unit.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");

            var planetUnits = new List<IUnit>() { unit.Object };

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetX");
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            path.Setup(p => p.TargetLocation.Planet.Units).Returns(planetUnits);

            var map = new List<IPath>() { path.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            string expected = "FREE LUNCH";

            // Act & Assert
            var ex = Assert.Throws<InsufficientResourcesException>(
                () => teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object));
            StringAssert.Contains(
                expected,
                ex.Message,
                "Expected string is not found within the actual message!");
        }

        [Test]
        public void TeleportUnitShouldRequire_PaymentFromUnitToTeleportForProvidedServices_WhenTheUnitIsReadyForTeleportation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unit = new Mock<IUnit>();
            unit.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unit.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);

            var planetUnits = new List<IUnit>() { unit.Object };

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            path.Setup(p => p.TargetLocation.Planet.Units).Returns(planetUnits);
            path.Setup(p => p.Cost.BronzeCoins).Returns(1U);
            path.Setup(p => p.Cost.GoldCoins).Returns(1U);
            path.Setup(p => p.Cost.SilverCoins).Returns(1U);

            var map = new List<IPath>() { path.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(path.Object.Cost)).Returns(path.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });
            
            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            unitToTeleport.Verify(u => u.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void TeleportUnitShould_ObtainPaymentFromUnitToTeleportForTheProvidedServices()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unit = new Mock<IUnit>();
            unit.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unit.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);

            var planetUnits = new List<IUnit>() { unit.Object };

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            path.Setup(p => p.TargetLocation.Planet.Units).Returns(planetUnits);
            path.Setup(p => p.Cost.BronzeCoins).Returns(1U);
            path.Setup(p => p.Cost.GoldCoins).Returns(1U);
            path.Setup(p => p.Cost.SilverCoins).Returns(1U);

            var map = new List<IPath>() { path.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Name).Returns("PlanetX");
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");

            var teleportStation = new TeleportStationFake(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(path.Object.Cost)).Returns(path.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);

            var expectedBronze = teleportStation.Resources.BronzeCoins + path.Object.Cost.BronzeCoins;
            var expectedGold = teleportStation.Resources.GoldCoins + path.Object.Cost.GoldCoins;
            var expectedSilver = teleportStation.Resources.SilverCoins + path.Object.Cost.SilverCoins;

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            Assert.AreEqual(expectedBronze, teleportStation.Resources.BronzeCoins, "bronzeCoins");
            Assert.AreEqual(expectedGold, teleportStation.Resources.GoldCoins, "goldCoins");
            Assert.AreEqual(expectedSilver, teleportStation.Resources.SilverCoins, "silverCoins");
        }

        [Test]
        public void TeleportUnitShould_SetThe_unitToTeleport_PreviousLocationTo_unitToTeleport_CurrentLocation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unitInCity = new Mock<IUnit>();
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            path.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetX");
            path.Setup(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCity.Object });
            path.Setup(p => p.Cost).Returns(new Resources(10, 10, 10));

            var map = new List<IPath>() { path.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            location.Setup(l => l.Planet.Name).Returns("PlanetX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(path.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });
            
            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);

            var expectedPreviousLocation = unitToTeleport.Object.CurrentLocation;

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            unitToTeleport.VerifySet(u => u.PreviousLocation = u.CurrentLocation);
        }

        [Test]
        public void TeleportUnitShould_SetThe_unitToTeleport_CurrentLocationTo_TargetLocationWhenTheUnitIsBeingTeleported()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unitInCity = new Mock<IUnit>();
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);

            var path = new Mock<IPath>();
            path.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            path.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetX");
            path.Setup(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCity.Object });
            path.Setup(p => p.Cost).Returns(new Resources(10, 10, 10));

            var map = new List<IPath>() { path.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            location.Setup(l => l.Planet.Name).Returns("PlanetX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(path.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);

            var expectedPreviousLocation = unitToTeleport.Object.CurrentLocation;

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            unitToTeleport.VerifySet(u => u.CurrentLocation = targetLocation.Object);
        }

        [Test]
        public void TeleportUnitShould_AddThe_unitToTeleportToTheListOfUnitsOfTheTargetLocation_Planet_Units_WhenUnitIsOnItsWayToBeTeleported()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unitInCity = new Mock<IUnit>();
            unitInCity.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitInCity.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(l => l.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(l => l.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(l => l.Coordinates.Longtitude).Returns(1.1);
            targetLocation.Setup(l => l.Planet.Units).Returns(new List<IUnit>());

            var pathToTarget = new Mock<IPath>();
            pathToTarget.Setup(p => p.TargetLocation).Returns(targetLocation.Object);
            pathToTarget.Setup(p => p.Cost).Returns(new Resources(10, 10, 10));

            var map = new List<IPath>() { pathToTarget.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            location.Setup(l => l.Planet.Name).Returns("PlanetX");

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns(location.Object.Planet.Galaxy.Name);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns(location.Object.Planet.Name);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(pathToTarget.Object.Cost);

            location.Setup(l => l.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(location.Object.Planet.Units);
            
            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            Assert.AreEqual(targetLocation.Object.Planet.Units.Last(), unitToTeleport.Object);
        }

        [Test]
        public void TeleportUnitShould_Remove_unitToTeleportFromTheListOfUnitsOfThe_unit_CurrentLocation_Planet_Units_WhenUnitIsOnItsWayToBeTeleported()
        {
            // TeleportUnit should Remove the unitToTeleport from the list of Units of the unit's current
            // location (Planet.Units), when all of the validations pass successfully and the unit is on its way
            // to being teleported
            // Arrange
            var owner = new Mock<IBusinessOwner>();

            var unitInCity = new Mock<IUnit>();
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(2.2);
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(2.2);
            unitInCity.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitInCity.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");

            var pathToTarget = new Mock<IPath>();
            pathToTarget.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            pathToTarget.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetX");
            pathToTarget.Setup(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCity.Object });
            pathToTarget.Setup(p => p.Cost).Returns(new Resources(10, 10, 10));

            var map = new List<IPath>() { pathToTarget.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            location.Setup(l => l.Planet.Name).Returns("PlanetX");

            var teleportStation = new TeleportStation(owner.Object, map, location.Object);

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(pathToTarget.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(tl => tl.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(tl => tl.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(tl => tl.Coordinates.Latitude).Returns(1.1);
            targetLocation.Setup(tl => tl.Coordinates.Longtitude).Returns(1.1);

            // Act
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            // Assert
            Assert.IsFalse(unitToTeleport.Object.CurrentLocation.Planet.Units.Contains(unitToTeleport.Object));
        }

        [Test]
        public void PayProfitsShould_ReturnTotalAmountOfResourcesGeneratedUsingTheTeleportUnitService_WhenTheArgumentPassedRepresentsTheActualOwnerOfTheTeleportStation()
        {
            // Arrange
            var owner = new Mock<IBusinessOwner>();
            owner.Setup(o => o.IdentificationNumber).Returns(7);
            owner.Setup(o => o.NickName).Returns("Anastasia");

            var unitInCity = new Mock<IUnit>();
            unitInCity.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitInCity.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Latitude).Returns(1.1);
            unitInCity.Setup(u => u.CurrentLocation.Coordinates.Longtitude).Returns(1.1);

            var pathToTarget = new Mock<IPath>();
            pathToTarget.Setup(p => p.TargetLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            pathToTarget.Setup(p => p.TargetLocation.Planet.Name).Returns("PlanetX");
            pathToTarget.Setup(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>() { unitInCity.Object });
            pathToTarget.Setup(p => p.Cost).Returns(new Resources(1000, 1000, 1000));

            var map = new List<IPath>() { pathToTarget.Object };

            var location = new Mock<ILocation>();
            location.Setup(l => l.Planet.Galaxy.Name).Returns("GalaxyX");
            location.Setup(l => l.Planet.Name).Returns("PlanetX");

            var unitToTeleport = new Mock<IUnit>();
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Galaxy.Name).Returns("GalaxyX");
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Name).Returns("PlanetX");
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(pathToTarget.Object.Cost);
            unitToTeleport.Setup(u => u.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { unitToTeleport.Object });

            var targetLocation = new Mock<ILocation>();
            targetLocation.Setup(tl => tl.Planet.Galaxy.Name).Returns("GalaxyX");
            targetLocation.Setup(tl => tl.Planet.Name).Returns("PlanetX");
            targetLocation.Setup(tl => tl.Coordinates.Latitude).Returns(2.2);
            targetLocation.Setup(tl => tl.Coordinates.Longtitude).Returns(2.2);

            var teleportStation = new TeleportStationFake(owner.Object, map, location.Object);
            teleportStation.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            var expectedProfits = pathToTarget.Object.Cost;

            // Act
            var actualProfits = teleportStation.PayProfits(owner.Object);

            // Assert
            Assert.AreEqual(expectedProfits.BronzeCoins, actualProfits.BronzeCoins, "bronzeCoins");
            Assert.AreEqual(expectedProfits.GoldCoins, actualProfits.GoldCoins, "goldCoins");
            Assert.AreEqual(expectedProfits.SilverCoins, actualProfits.SilverCoins, "silverCoins");
        }
    }
}
