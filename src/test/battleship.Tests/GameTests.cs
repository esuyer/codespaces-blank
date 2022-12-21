using battleship;

namespace battleship.Tests {


    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGameLevelEasy()
        {
           
            var l = GameLevelFactory.Make(GameLevelChoice.Easy);
            Assert.IsTrue(l is EasyGameLevel, "Good");
            

            
        }
    }
}