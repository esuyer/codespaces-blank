using battleship;

namespace battleship.Tests {


    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void NewMapTest()
        {
            var m = new Map(GameLevelFactory.Make(GameLevelChoice.Easy));
            foreach(Cell c in m.Grid) Console.WriteLine("row: {0} col: {1} value: {2}", c.Coordinate.Row, c.Coordinate.Col, c.Val);
            Assert.IsTrue(true, "Good");

        }
    }
}