namespace battleship 
{

    public enum CellValue 
    {
        Blank,
        White,
        Red
    }

    public class Cell
    {
        public Coordinate Coordinate {get; set;}

        public CellValue Val {get; set;}

        public Cell(char row, int col)
        {
            Coordinate = new Coordinate(row, col);
            Val = CellValue.Blank;
        }
    }

    public class Map
    {
        List<Cell> grid; 

        public List<Cell> Grid {get {return grid;}}

        public event EventHandler<MissleStrikeArgs>? MissleStrike;

        public void OnMissleStrike(MissleStrikeArgs e) 
        {
            MissleStrike?.Invoke(this, e);
        }
        
        public Map()
        {
            grid = new List<Cell>(100);
            foreach (char r in "ABCDEFGHIJ")
            {
                foreach(int c in new int[] {1,2,3,4,5,6,7,8,9,10})
                {
                    grid.Add(new Cell(r, c));
                }
            }
        }

        public MissleStrikeOutcome FireMissle(char row, int col)
        {
            var cell = grid.Find(x => x.Coordinate.Row == row && x.Coordinate.Col == col);
            if (cell != null) {
                                
                var args = new MissleStrikeArgs(row, col);
                this.OnMissleStrike(args);
                
                cell.Val = (args.Outcome == MissleStrikeOutcome.Miss ? CellValue.White : CellValue.Red );
                return args.Outcome;
            }

            return MissleStrikeOutcome.Miss;
        }
    }
}
