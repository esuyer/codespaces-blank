namespace battleship 
{
    public class Game
    {
        List<WarShip> ships;
        Map map;

        public Game() : this(GameLevelFactory.Make(GameLevelChoice.Easy))
        {
        }

        public Game(IGameLevel level) 
        {
            ships = new List<WarShip>();
            map =  new Map(level);
        }


        public Map Map { get {return map;} }

        public List<WarShip> Ships { get {return ships;} }

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