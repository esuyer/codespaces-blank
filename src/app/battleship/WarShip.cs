namespace battleship 
{

    public enum PartState
    {
        Afloat,
        Sunk
    }


    public class ShipPart
    {
        public Coordinate Coordinate {get; set;}
        public PartState State {get; set;}

        public ShipPart(Coordinate loc)
        {
            Coordinate = new Coordinate(loc.Row, loc.Col);
            State = PartState.Afloat;
        }

    }
    public abstract class WarShip
    {
        List<ShipPart> footprint = new List<ShipPart>();

        public List<ShipPart> Footprint {get {return footprint;}}

        public void HandleMissleStrike(object? sender, MissleStrikeArgs e)
        {
            if (sender is Map map)
            {
                var p = footprint.Find(x => x.Coordinate.Row == e.Coordinate.Row && x.Coordinate.Col == e.Coordinate.Col);
                if (p !=null) {
                    p.State = PartState.Sunk;
                    e.Outcome = MissleStrikeOutcome.Hit;
                }
            }
        }

        public bool IsSunk {
            get {
                return (footprint.Find(x => x.State == PartState.Afloat) == null);
            }
        }

        public WarShip(Coordinate[] coordinates)
        {
            foreach(Coordinate coordinate in coordinates) footprint.Add(new ShipPart(coordinate));
        }

    }

    public class Carrier : WarShip
    {
        public Carrier(Coordinate[] coordinates) : base(coordinates)
        {
        }
    }

   public class Battleship : WarShip
    {
        public Battleship(Coordinate[] coordinates) : base(coordinates)
        {
        }
    }

   public class Destroyer : WarShip
    {
        public Destroyer(Coordinate[] coordinates) : base(coordinates)
        {
        }
    }

    public class Submarine : WarShip
    {
        public Submarine(Coordinate[] coordinates) : base(coordinates)
        {
        }
    }

   public class PatrolBoat : WarShip
    {
        public PatrolBoat(Coordinate[] coordinates) : base(coordinates)
        {
        }
    }
}