using System;
using System.Diagnostics;
using consoleApp;
using battleship;

namespace consoleApp.Tests
{

    [TestClass]
    public class ConsoleAppTests
    {
        [TestMethod]
        public void DisplayAppUsageTest()
        {
            ConsoleApp c = new ConsoleApp();
            c.DisplayAppUsage();
            Assert.IsTrue(true, "Display usage details of battleship.exe");
         
        }

        [TestMethod]
        public void DisplayGameSplashTest()
        {
            ConsoleApp c = new ConsoleApp();
            c.DisplayGameSplash();
            Assert.IsTrue(true, "Display splah screen a player will see when they start the game of battleship");
        }

        [TestMethod]
        public void DisplayGameInstructionsTest()
        {
            ConsoleApp c = new ConsoleApp();
            c.DisplayGameInstructions();
            Assert.IsTrue(false, "Display instructions for the game of battleship");
        }

        [TestMethod]
        public void DisplayMapTest()
        {
            ConsoleApp c = new ConsoleApp();
            c.DisplayMap(new Map());
            Assert.IsTrue(false, "Display the 10x10 map.  Empty spaces are marked with E.  Misses with W(hite) and Hits with R(ed).");
        }

        [TestMethod]
        public void DisplayShipsTest()
        {
            ConsoleApp c = new ConsoleApp();
            var s = new Carrier(new Coordinate[]{ 
                new Coordinate('B', 10), 
                new Coordinate('C', 10), 
                new Coordinate('D', 10), 
                new Coordinate('E', 10), 
                new Coordinate('F', 10)});
            
            c.DisplayShips(new List<WarShip>(){s});
            Assert.IsTrue(false, "Display the ships and their state.  Each ship is made of multiple parts.  Each part is either S(unk) or A(float).  If all parts are Sunk then the ship is Sunk");
        }

        
        [TestMethod]
        public void FireMissleMissTest()
        {
            ConsoleApp c = new ConsoleApp();
            Game game = new Game();
            game.Setup();

            char row = 'A';
            int col = 10;
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", row, col, game.FireMissle(row, col)));
            c.DisplayMap(game.Map);
            c.DisplayShips(game.Ships);

            Assert.IsTrue(false, "Fire missle to x and y coordinate");
        }

        
        [TestMethod]
        public void FireMissleHitTest()
        {
            ConsoleApp c = new ConsoleApp();
            Game game = new Game();
            game.Setup();

            char row = 'B';
            int col = 10;
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", row, col, game.FireMissle(row, col)));
            c.DisplayMap(game.Map);
            c.DisplayShips(game.Ships);

            Assert.IsTrue(false, "Fire missle to x and y coordinate");
        }

        
        [TestMethod]
        public void FireMissleHitAndSinkTest()
        {
            ConsoleApp c = new ConsoleApp();
            Game game = new Game();
            game.Setup();

            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", 'B', 10, game.FireMissle('B', 10)));
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", 'C', 10, game.FireMissle('C', 10)));
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", 'D', 10, game.FireMissle('D', 10)));
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", 'E', 10, game.FireMissle('E', 10)));
            Trace.WriteLine(string.Format("Missle fired to coordinate {0}, {1}: {2}", 'F', 10, game.FireMissle('F', 10)));
            c.DisplayMap(game.Map);
            c.DisplayShips(game.Ships);
        }
        

    }
}