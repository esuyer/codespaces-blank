namespace battleship 
{

    public enum MissleStrikeOutcome
    {
        Miss,
        Hit
    }

    public class MissleStrikeArgs : EventArgs
    {

        public Coordinate Coordinate {get; set;}


        public MissleStrikeOutcome Outcome { set; get; }

        public MissleStrikeArgs(char row, int col)
        {
            Coordinate = new Coordinate(row, col);
        } 
    }


}