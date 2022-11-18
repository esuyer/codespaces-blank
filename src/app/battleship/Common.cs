namespace battleship 
{
    
    public class Coordinate
    {
        public char Row {get; set;}
        public int Col {get; set;}

        public Coordinate(char row, int col)
        {
            Row = row;
            Col = col;
        }
    }

}