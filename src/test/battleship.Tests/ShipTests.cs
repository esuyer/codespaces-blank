using battleship;

namespace battleship.Tests {


    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void NewCarrier()
        {
            var s = new Carrier(new Coordinate[]{ 
                new Coordinate('B', 10), 
                new Coordinate('C', 10), 
                new Coordinate('D', 10), 
                new Coordinate('E', 10), 
                new Coordinate('F', 10)});
            foreach(ShipPart p in s.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);
            Assert.IsTrue(true, "Good");
        }

        [TestMethod]
        public void NewBattleship()
        {
            var s = new Battleship(new Coordinate[]{ 
                new Coordinate('E', 8), 
                new Coordinate('F', 8), 
                new Coordinate('G', 8), 
                new Coordinate('H', 8)});
            foreach(ShipPart p in s.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);
            Assert.IsTrue(true, "Good");
        }

        [TestMethod]
        public void NewDestroyer()
        {
            var s = new Destroyer(new Coordinate[]{ 
                new Coordinate('G', 3), 
                new Coordinate('G', 4), 
                new Coordinate('G', 5)});
            foreach(ShipPart p in s.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);
            Assert.IsTrue(true, "Good");
        }

        [TestMethod]
        public void NewSub()
        {
            var s = new Submarine(new Coordinate[]{ 
                new Coordinate('B', 2), 
                new Coordinate('C', 2)});
            foreach(ShipPart p in s.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);

            var t = new Submarine(new Coordinate[]{ 
                new Coordinate('E', 4), 
                new Coordinate('E', 5)});
            foreach(ShipPart p in t.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);

            Assert.IsTrue(true, "Good");
        }

        [TestMethod]
        public void NewPatrolBoat()
        {
            var s = new PatrolBoat(new Coordinate[]{ 
                new Coordinate('C', 4)});
            foreach(ShipPart p in s.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);

            var t = new PatrolBoat(new Coordinate[]{ 
                new Coordinate('I', 2)});
            foreach(ShipPart p in t.Footprint) Console.WriteLine("row: {0} col: {1} state: {2}", p.Coordinate.Row, p.Coordinate.Col, p.State);

            Assert.IsTrue(true, "Good");
        }

        [TestMethod]
        public void ShipIsSunkTest()
        {
            var s = new PatrolBoat(new Coordinate[] {
                new Coordinate('C', 4)});

            // change the state of C4 to a Hit
            var m = new Map();
            var l = new List<WarShip>();

            m.MissleStrike += s.HandleMissleStrike;
            l.Add(s);

            m.FireMissle('C', 4);
            // check if the ship is sunk
            Assert.IsTrue(s.IsSunk, "Ship is Sunk");

        }

        [TestMethod]
        public void FireAndMiss()
        {
            var s = new PatrolBoat(new Coordinate[] {
                new Coordinate('C', 4)});

            // change the state of C4 to a Hit
            var m = new Map();
            var l = new List<WarShip>();

            m.MissleStrike += s.HandleMissleStrike;
            l.Add(s);

            m.FireMissle('D', 4);

            // check if the ship is sunk
            Assert.IsFalse(s.IsSunk, "Ship is not Sunk");

        }


    }
}