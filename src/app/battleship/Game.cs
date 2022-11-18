namespace battleship 
{
    public class Game
    {
        List<WarShip> ships;
        Map map;

        public Game() 
        {
            ships = new List<WarShip>();
            map =  new Map();
        }
        
        public void Setup()
        {
            // add a carrier
            var c = new Carrier(new Coordinate[]{ 
                new Coordinate('B', 10), 
                new Coordinate('C', 10), 
                new Coordinate('D', 10), 
                new Coordinate('E', 10), 
                new Coordinate('F', 10)});

            map.MissleStrike += c.HandleMissleStrike;
            ships.Add(c);


        }

        public MissleStrikeOutcome FireMissle(char row, int col)
        {
            return map.FireMissle(row, col);
        }
    }

}