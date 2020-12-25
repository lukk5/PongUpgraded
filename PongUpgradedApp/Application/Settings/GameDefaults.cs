
namespace PongUpgraded.Application.Settings
{
    public static class GameDefaults
    {
        public static int MaxSizeX => 100;
        public static int MaxSizeY => 28;
        public static char FirstPlayerSymbol => '|';
        public static char SecondPlayerSymbol => '|';
        public static char BallSymbol => '0';
        public static int StartY => MaxSizeY / 2;
        public static int Possibility => 70;
        public static int GameLevel3 => 350;
        
        public static int GameLevel2 => 280;
        
        public static int GameLevel1 => 220;

        public static bool BallDirectionX => false;
        public static bool BallDirectionY => false;
        public static int BallStartY => MaxSizeY / 2;
        public static int BallStartX => MaxSizeX / 2;
        public static int MinSizeX => 1;
        public static int MinSizeY => 0;
        public static int MaxScoreForLose => 5;
        public static int ScoreX => MaxSizeX / 2;
        public static int ScoreY => MaxSizeY + 5;
        public static int SlowDownTime => 100;
    }
}
