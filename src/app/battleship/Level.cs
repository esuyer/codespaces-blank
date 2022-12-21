namespace battleship 
{

    public interface IGameLevel
    {
        public int GridSize {get;}
    }

    public enum GameLevelChoice
    {
        Easy,
        Medium,
        Hard
    }

    public class EasyGameLevel : IGameLevel
    {
        public EasyGameLevel(){}

        public int GridSize {get {return 10;}}
    }

    public class GameLevelFactory
    {
        public static IGameLevel Make(GameLevelChoice choice)
        {
            switch (choice)
            {
                case GameLevelChoice.Easy:
                    return new EasyGameLevel();
                
                case GameLevelChoice.Medium:
                    return new EasyGameLevel();

                case GameLevelChoice.Hard:
                    return new EasyGameLevel();

                default:
                    return new EasyGameLevel();
            }
            
        }
    }

}