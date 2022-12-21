namespace battleship 
{
    public class AwareCell : Cell
    {
        public int OffsetNorth {get; set;}
        public int OffsetEast {get; set;}
        public int OffsetSouth {get; set;}
        public int OffsetWest {get; set;}

        public AwareCell(char row, int col, int offsetNorth, int offsetEast, int offsetSouth, int offsetWest) : base(row, col)
        {
            OffsetEast = offsetEast;
            OffsetNorth = offsetNorth;
            OffsetSouth = offsetSouth;
            OffsetWest = offsetWest;
        }

    }

    public enum ShipDirection
    {
        North,
        East,
        South,
        West
    }

    public enum BattleshipType
    {
        Carrier,
        Battleship,
        Destroyer,
        Submarine,
        PatrolBoat
    }

    public interface IShipPlacer
    {
        public WarShip? PlaceShip(BattleshipType type);
    }

    public class RandomShipPlacer : IShipPlacer
    {
        List<AwareCell> grid; 
        int gridSize = 0;

        public RandomShipPlacer() : this(GameLevelFactory.Make(GameLevelChoice.Easy))
        {
        }

        public RandomShipPlacer(IGameLevel level) 
        {
            grid = new List<AwareCell>(level.GridSize * level.GridSize);
            gridSize = level.GridSize;

            int rowStart = 65;  // 'A'
            int colStart = 1;

            for (int r = 0; r < level.GridSize; r++)
            {
                for (int c = 0; c < level.GridSize; c++)
                {
                    // initialize aware cell.  Set off sets to grid borders
                    var cell = new AwareCell (
                        (char)(rowStart + r), 
                        colStart + c,
                        r,  // North
                        level.GridSize - colStart - c,  // East
                        level.GridSize - r, // South
                        colStart + c - 1); // West

                    grid.Add(cell);
                }
            }

        }

        public WarShip? PlaceShip(BattleshipType type)
        {


            int shipSize = 5;   // to do: replace this with logic to determine ship size
            bool shipPlaced = false;

            Random rnd = new Random();

            do { 
                /* randomly identify ship direction */
                var enums = (ShipDirection[])Enum.GetValues(typeof(ShipDirection));  
                var direction = Enum.Parse(typeof(ShipDirection),enums[rnd.Next(0,3)].ToString());                 

                /* randomly identify index of target cell to place the ship */
                var cellIdx = rnd.Next(0, (this.gridSize * this.gridSize) -1);    
                var cell = this.grid[cellIdx];

                switch (direction)
                {
                    case ShipDirection.North:
                        if (cell.OffsetNorth >= shipSize) {
                            shipPlaced = true;
                            return new Carrier(new Coordinate[]{ 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row - 1), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row - 2), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row - 3), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row - 4), cell.Coordinate.Col) 
                                });
                        }
                    break;

                    case ShipDirection.East:
                        if (cell.OffsetEast >= shipSize) {
                            shipPlaced = true;
                            return new Carrier(new Coordinate[]{ 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col+1), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col+2), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col+3), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col+4), 
                                });
                        }
                    break;

                    case ShipDirection.South:
                        if (cell.OffsetSouth >= shipSize) {
                            shipPlaced = true;
                            return new Carrier(new Coordinate[]{ 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row + 1), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row + 2), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row + 3), cell.Coordinate.Col), 
                                new Coordinate((char)((int)cell.Coordinate.Row + 4), cell.Coordinate.Col) 
                                });
                        }
                    break;

                    case ShipDirection.West:
                        if (cell.OffsetWest >= shipSize) {
                            shipPlaced = true;
                            return new Carrier(new Coordinate[]{ 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col-1), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col-2), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col-3), 
                                new Coordinate(cell.Coordinate.Row, cell.Coordinate.Col-4), 
                                });
                        }
                    break;

                }

            } while (!shipPlaced);
                
            return null;    
        }
    }
}