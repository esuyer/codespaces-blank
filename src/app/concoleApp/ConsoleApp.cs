using System;
using System.Diagnostics;
using battleship;

namespace consoleApp {

    public class ConsoleApp
    {
        public ConsoleApp() {}

        public void DisplayAppUsage()
        {
            Trace.WriteLine("Usage: battleship [runtime-options]");
            Trace.WriteLine("");
            Trace.WriteLine("Play the game of battleship");
            Trace.WriteLine("");
            Trace.WriteLine("runtime-options:");
            Trace.WriteLine(string.Format(" -{0}                                {1}", "h", "Show command line help.  This usage screen"));
            Trace.WriteLine("");
        }

        public void DisplayGameSplash()
        {
            Trace.WriteLine("Welcome to the game of battleship!");
            Trace.WriteLine(string.Format("We have randomly places {0} battle ships on a {1}x{1} map", 5, 10));
            Trace.WriteLine("The object of the game is to sink all battle ships by deducing their location through firing missles");
            Trace.WriteLine(string.Format("You have an arsenal of {0} missles.  Each time you hit a ship, you get an additional {1} missles", 20, 5));
            Trace.WriteLine("You fire missles by entering a coordinate on the map.  For example coordinate A1 will fire a missle to the map cell A1");
            Trace.WriteLine("Good luck and may the force be with you!");
            Trace.WriteLine("");
        }

        public void DisplayGameInstructions()
        {
         
        }

        public void DisplayMap(Map map)
        {
            char rowIdx = 'A';
            foreach(Cell c in map.Grid)
            {
                if (rowIdx != c.Coordinate.Row)
                {
                    rowIdx = c.Coordinate.Row;
                    Trace.WriteLine("");
                }
                Trace.Write(string.Format("{0}",c.Val.ToString().Substring(0,1)));
            }
            Trace.WriteLine("");
        }

        public void DisplayShips(List<WarShip> ships)
        {
            foreach(WarShip ship in ships)
            {
                Trace.Write(string.Format("{0} :",ship.GetType()));
                foreach(ShipPart part in ship.Footprint)
                {
                    Trace.Write(string.Format("{0}",part.State.ToString().Substring(0,1)));
                }
                Trace.WriteLine("");
            }
            Trace.WriteLine("");
        }

        public void FireMissle()
        {

        }

    }
}