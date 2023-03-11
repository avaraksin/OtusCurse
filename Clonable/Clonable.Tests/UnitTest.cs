using Xunit;

namespace Clonable.Tests
{
    /// <summary>
    /// ���� MyClone()
    /// </summary>
    public class UnitTest
    {
        /// <summary>
        /// ���� ������������ ShipRoute
        /// </summary>
        [Fact]
        public void TestShipRoute_MyClone()
        {
            ShipRoute shipRoute = new ShipRoute("TestLot", new DateTime(2023, 11, 21), new DateTime(2023, 12, 22));
            shipRoute.ShipName = "TestShip";

            ShipRoute anotherShip = shipRoute.MyClone();

            Assert.NotEqual(shipRoute, anotherShip);
            Assert.Equal(shipRoute.Lot, anotherShip.Lot);
            Assert.Equal(shipRoute.ETD, anotherShip.ETD);
            Assert.Equal(shipRoute.ETA, anotherShip.ETA);
            Assert.Equal(shipRoute.Destination, anotherShip.Destination);
            Assert.Equal(shipRoute.Source, anotherShip.Source);
        }

        /// <summary>
        /// ���� ������������ RWRoute
        /// </summary>
        [Fact]
        public void TestRWRoute_MyClone()
        {
            RWRoute rwRoute = new RWRoute("TestLot", new DateTime(2023, 11, 21), new DateTime(2023, 12, 22));
            rwRoute.Platform = "TestShip";

            RWRoute anotherShip = rwRoute.MyClone();

            Assert.NotEqual(rwRoute, anotherShip);
            Assert.Equal(rwRoute.Lot, anotherShip.Lot);
            Assert.Equal(rwRoute.ETD, anotherShip.ETD);
            Assert.Equal(rwRoute.ETA, anotherShip.ETA);
            Assert.Equal(rwRoute.Destination, anotherShip.Destination);
            Assert.Equal(rwRoute.Source, anotherShip.Source);
            Assert.Equal(rwRoute.Platform, anotherShip.Platform);
        }

        /// <summary>
        /// ���� ������������ InterRoute
        /// </summary>
        [Fact]
        public void TestInterRoute_MyClone()
        {
            InterRoute interRoute = new ("TestLot", new DateTime(2023, 11, 21), new DateTime(2023, 12, 22));
            interRoute.Ship = new ShipRoute(interRoute.Lot, interRoute.ETD, interRoute.ETA);
            interRoute.Ship.ShipName = "ShipName";
            interRoute.RWRoute = new RWRoute(interRoute.Lot, interRoute.ETD, interRoute.ETA);
            interRoute.RWRoute.Platform = "Platform";

            InterRoute anotherInter = interRoute.MyClone();

            Assert.NotEqual(interRoute, anotherInter);
            Assert.Equal(interRoute.Lot, anotherInter.Lot);
            Assert.Equal(interRoute.ETD, anotherInter.ETD);
            Assert.Equal(interRoute.ETA, anotherInter.ETA);
            Assert.Equal(interRoute.Destination, anotherInter.Destination);
            Assert.Equal(interRoute.Source, anotherInter.Source);
            
            // ���������� ��� ������� Ship �� ��������� �� ���� � ��� �� ������
            Assert.NotEqual(interRoute.Ship, anotherInter.Ship);
            // ��, �������� ���������� ��������
            Assert.Equal(interRoute.Ship.ShipName, anotherInter.Ship?.ShipName);

            Assert.NotEqual(interRoute.RWRoute, anotherInter.RWRoute);
            Assert.Equal(interRoute.RWRoute.Platform, anotherInter.RWRoute?.Platform);
        }

        /// <summary>
        /// ���� ������������ DomesticRoute
        /// </summary>
        [Fact]
        public void TestDomesticRoute_MyClone()
        {
            DomesticRoute domesticRoute = new ("TestLot", new DateTime(2023, 11, 21), new DateTime(2023, 12, 22));
         
            domesticRoute.RWRoute = new RWRoute(domesticRoute.Lot, domesticRoute.ETD, domesticRoute.ETA);
            domesticRoute.RWRoute.Platform = "Platform";

            DomesticRoute anotheDomestic = domesticRoute.MyClone();

            Assert.NotEqual(domesticRoute, anotheDomestic);
            Assert.Equal(domesticRoute.Lot, anotheDomestic.Lot);
            Assert.Equal(domesticRoute.ETD, anotheDomestic.ETD);
            Assert.Equal(domesticRoute.ETA, anotheDomestic.ETA);
            Assert.Equal(domesticRoute.Destination, anotheDomestic.Destination);
            Assert.Equal(domesticRoute.Source, anotheDomestic.Source);

            // � ������ DomesticRoute ������ Ship ������ ����� null
            Assert.Null(domesticRoute.Ship);

            Assert.NotEqual(domesticRoute.RWRoute, anotheDomestic.RWRoute);
            Assert.Equal(domesticRoute.RWRoute.Platform, anotheDomestic.RWRoute?.Platform);
        }
    }
}