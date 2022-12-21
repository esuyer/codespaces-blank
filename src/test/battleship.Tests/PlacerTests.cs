using battleship;

namespace battleship.Tests {


    [TestClass]
    public class PlacerTests
    {
        [TestMethod]
        public void TestRandomShipPlacer()
        {
           
            var p = new RandomShipPlacer();
            Assert.IsTrue(p is RandomShipPlacer, "Good");
            
        }

        [TestMethod]
        public void TestPlaceCarrier()
        {
           
            var p = new RandomShipPlacer();
            var s = p.PlaceShip(BattleshipType.Carrier);
            Assert.IsTrue(s.Footprint.Count > 0, "Good");
            
        }

    }
}