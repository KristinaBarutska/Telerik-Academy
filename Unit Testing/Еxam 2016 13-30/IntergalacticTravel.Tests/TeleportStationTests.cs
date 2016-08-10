namespace IntergalacticTravel.Tests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Mocks;
    using Contracts;
    using System.Collections.Generic;
    using Exceptions;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_ValidParameters_ShouldSetOwnerGalacticMapAndLocation()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var station = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            Assert.IsTrue(
                (station.Owner == owner.Object) &&
                (station.GalacticMap == galacticMap.Object) &&
                (station.Location == location.Object)
            );
        }

        [Test]
        public void TeleportUnit_NullUnitToTeleport_ShouldThrowArgumentNullException()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var targetLocation = new Mock<ILocation>();
            var station = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            try
            {
                station.TeleportUnit(null, targetLocation.Object);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.Message.Contains("unitToTeleport"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_NullDestination_ShouldThrowArgumentNullException()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var unitToTeleport = new Mock<IUnit>();
            var station = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.Message.Contains("destination"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_ValidParamsButDistantUnitLocation_ShouldThrowTeleportOutOfRangeException()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("First Galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();

            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Second Galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var station = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch (TeleportOutOfRangeException e)
            {
                Assert.IsTrue(e.Message.Contains("unitToTeleport.CurrentLocation"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_TryToTeleportToAlreadyTakenLocation_ShouldThrowInvalidTeleportationLocationException()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();

            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();

            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch (InvalidTeleportationLocationException e)
            {
                Assert.IsTrue(e.Message.Contains("units will overlap"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_TargetLocationThatDoesNotExist_ShouldThrowLocationNotFoundException()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();

            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Djidjibidji");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("First Galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();

            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("First Galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();

            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, location.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch (LocationNotFoundException e)
            {
                Assert.IsTrue(e.Message.Contains("Galaxy"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_TargetLocationPlanetThatDoesNotExist_ShouldThrowLocationNotFoundException()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();

            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("First Galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();

            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("First Galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();

            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Name).Returns("Some name");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, location.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch (LocationNotFoundException e)
            {
                Assert.IsTrue(e.Message.Contains("Planet"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_NotEnoughResourcesToPay_ShouldThrowInsufficientResourcesException()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();

            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new TeleportStation(owner.Object, galacticMap, targetLocation.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch (InsufficientResourcesException e)
            {
                Assert.IsTrue(e.Message.Contains("FREE LUNCH"));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TeleportUnit_ShouldRequirePaymentFromTheUnitToTeleport()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();
            var resultOfPayment = new Mock<IResources>();

            resultOfPayment.SetupGet(r => r.BronzeCoins).Returns(10);
            resultOfPayment.SetupGet(r => r.SilverCoins).Returns(10);
            resultOfPayment.SetupGet(r => r.GoldCoins).Returns(10);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);
            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(resultOfPayment.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);

            try
            {
                station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);
            }
            catch
            {
                unitToTeleport.Verify(u => u.Pay(It.IsAny<IResources>()), Times.Once);
            }
        }

        [Test]
        public void TeleportUnit_AmountOfTheResourcesOfTheStationShouldBeIncreased()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();
            var resultOfPayment = new Mock<IResources>();
            uint costPerResource = 10;

            resultOfPayment.SetupGet(r => r.BronzeCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.SilverCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.GoldCoins).Returns(costPerResource);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitToTeleport.Object });
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);

            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(resultOfPayment.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);

            station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            Assert.IsTrue(
                station.Resources.BronzeCoins == costPerResource &&
                station.Resources.SilverCoins == costPerResource &&
                station.Resources.GoldCoins == costPerResource);
        }

        [Test]
        public void TeleportUnit_ShouldSetUnitToTeleportPrevLocationToCurrentLocation()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();
            var resultOfPayment = new Mock<IResources>();
            uint costPerResource = 10;
            ILocation prevUnitLocationAfterSet = null;

            resultOfPayment.SetupGet(r => r.BronzeCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.SilverCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.GoldCoins).Returns(costPerResource);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.SetupSet(u => u.PreviousLocation = It.IsAny<ILocation>()).Callback<ILocation>(v => prevUnitLocationAfterSet = v);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitToTeleport.Object });
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);

            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(resultOfPayment.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);
            var unitToTeleportCachedPreviousLocation = unitToTeleport.Object.CurrentLocation;

            station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            Assert.AreEqual(prevUnitLocationAfterSet, unitToTeleportCachedPreviousLocation);
        }

        [Test]
        public void TeleportUnit_ShouldSetTargetLocationToCurrentLocation()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();
            var resultOfPayment = new Mock<IResources>();
            uint costPerResource = 10;
            ILocation prevUnitLocationAfterSet = null;
            ILocation currentLocationAfterSet = null;

            resultOfPayment.SetupGet(r => r.BronzeCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.SilverCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.GoldCoins).Returns(costPerResource);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.SetupSet(u => u.PreviousLocation = It.IsAny<ILocation>()).Callback<ILocation>(v => prevUnitLocationAfterSet = v);
            unitToTeleport.SetupSet(u => u.CurrentLocation = It.IsAny<ILocation>()).Callback<ILocation>(v => currentLocationAfterSet = v);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitToTeleport.Object });
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);

            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(resultOfPayment.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);
            var unitToTeleportCachedPreviousLocation = unitToTeleport.Object.CurrentLocation;

            station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            Assert.AreEqual(currentLocationAfterSet, targetLocation.Object);
        }

        [Test]
        public void TeleportUnit_ShouldRemoveTheUnitFromTheUnitsCurrentLocationPlanetUnits()
        {
            // Mocks for teleport station constructor
            var owner = new Mock<IBusinessOwner>();
            var pathInGalaxy = new Mock<IPath>();
            var pathLocation = new Mock<ILocation>();
            var pathLocationPlanet = new Mock<IPlanet>();
            var pathLocationPlanetGalaxy = new Mock<IGalaxy>();
            var unitInPlanet = new Mock<IUnit>();
            var unitInPlanetLocation = new Mock<ILocation>();
            var unitInPlanetLocationCoordinates = new Mock<IGPSCoordinates>();
            var unitInPlanetLocationPlanet = new Mock<IPlanet>();
            var unitInPlanetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var cost = new Mock<IResources>();

            cost.SetupGet(c => c.BronzeCoins).Returns(10);
            cost.SetupGet(c => c.SilverCoins).Returns(10);
            cost.SetupGet(c => c.GoldCoins).Returns(10);
            pathInGalaxy.SetupGet(p => p.Cost).Returns(cost.Object);
            unitInPlanetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitInPlanetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationPlanet.SetupGet(p => p.Galaxy).Returns(unitInPlanetLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitInPlanetLocationCoordinates.SetupGet(c => c.Latitude).Returns(2);
            unitInPlanetLocation.SetupGet(l => l.Coordinates).Returns(unitInPlanetLocationCoordinates.Object);
            unitInPlanetLocation.SetupGet(l => l.Planet).Returns(unitInPlanetLocationPlanet.Object);
            unitInPlanet.SetupGet(u => u.CurrentLocation).Returns(unitInPlanetLocation.Object);
            pathLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            pathLocationPlanet.SetupGet(p => p.Galaxy).Returns(pathLocationPlanetGalaxy.Object);
            pathLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitInPlanet.Object });
            pathLocation.SetupGet(l => l.Planet).Returns(pathLocationPlanet.Object);
            pathInGalaxy.SetupGet(p => p.TargetLocation).Returns(pathLocation.Object);

            var galacticMap = new List<IPath> { pathInGalaxy.Object };
            var location = new Mock<ILocation>();
            var currentLocationPlanet = new Mock<IPlanet>();
            var currentLocationPlanetGalaxy = new Mock<IGalaxy>();

            currentLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            currentLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            currentLocationPlanet.SetupGet(p => p.Galaxy).Returns(currentLocationPlanetGalaxy.Object);
            location.SetupGet(p => p.Planet).Returns(currentLocationPlanet.Object);

            // Unit to teleport
            var unitToTeleport = new Mock<IUnit>();
            var unitPlanet = new Mock<IPlanet>();
            var unitLocation = new Mock<ILocation>();
            var unitPlanetGalaxy = new Mock<IGalaxy>();
            var resultOfPayment = new Mock<IResources>();
            uint costPerResource = 10;
            ILocation prevUnitLocationAfterSet = null;
            ILocation currentLocationAfterSet = null;

            resultOfPayment.SetupGet(r => r.BronzeCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.SilverCoins).Returns(costPerResource);
            resultOfPayment.SetupGet(r => r.GoldCoins).Returns(costPerResource);
            unitToTeleport.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleport.SetupSet(u => u.PreviousLocation = It.IsAny<ILocation>()).Callback<ILocation>(v => prevUnitLocationAfterSet = v);
            unitToTeleport.SetupSet(u => u.CurrentLocation = It.IsAny<ILocation>()).Callback<ILocation>(v => currentLocationAfterSet = v);
            unitPlanet.SetupGet(p => p.Name).Returns("Planet");
            unitPlanet.SetupGet(p => p.Units).Returns(new List<IUnit> { unitToTeleport.Object });
            unitPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            unitPlanet.SetupGet(p => p.Galaxy).Returns(unitPlanetGalaxy.Object);
            unitLocation.SetupGet(l => l.Planet).Returns(unitPlanet.Object);

            unitToTeleport.SetupGet(u => u.CurrentLocation).Returns(unitLocation.Object);
            unitToTeleport.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(resultOfPayment.Object);

            // Target location
            var targetLocation = new Mock<ILocation>();
            var targetLocationPlanet = new Mock<IPlanet>();
            var targetLocationPlanetGalaxy = new Mock<IGalaxy>();
            var targetLocationCoordinates = new Mock<IGPSCoordinates>();

            targetLocationPlanet.SetupGet(p => p.Name).Returns("Planet");
            targetLocationPlanet.SetupGet(p => p.Units).Returns(new List<IUnit>());
            targetLocationCoordinates.SetupGet(c => c.Latitude).Returns(3);
            targetLocationPlanetGalaxy.SetupGet(g => g.Name).Returns("Some galaxy");
            targetLocationPlanet.SetupGet(p => p.Galaxy).Returns(targetLocationPlanetGalaxy.Object);
            targetLocation.SetupGet(l => l.Planet).Returns(targetLocationPlanet.Object);
            targetLocation.SetupGet(l => l.Coordinates).Returns(targetLocationCoordinates.Object);

            var station = new MockedTeleportStation(owner.Object, galacticMap, targetLocation.Object);
            var unitToTeleportCachedPreviousLocation = unitToTeleport.Object.CurrentLocation;

            station.TeleportUnit(unitToTeleport.Object, targetLocation.Object);

            Assert.AreEqual(0, unitToTeleport.Object.CurrentLocation.Planet.Units.Count);
        }

        [Test]
        public void PayProfits_ShouldReturnTheAmountOfProfitsGenerated()
        {
            var owner = new Mock<IBusinessOwner>();
            var galacticMap = new Mock<IEnumerable<IPath>>();
            var location = new Mock<ILocation>();
            var ownerToPass = new Mock<IBusinessOwner>();

            owner.SetupGet(o => o.IdentificationNumber).Returns(1);
            ownerToPass.SetupGet(o => o.IdentificationNumber).Returns(1);

            var station = new MockedTeleportStation(owner.Object, galacticMap.Object, location.Object);

            station.Resources.BronzeCoins = 10;
            station.Resources.SilverCoins = 10;
            station.Resources.GoldCoins = 10;

            var allProfits = station.PayProfits(ownerToPass.Object);

            Assert.IsTrue(
                allProfits.BronzeCoins == 10 &&
                allProfits.SilverCoins == 10 &&
                allProfits.GoldCoins == 10);
        }
    }
}