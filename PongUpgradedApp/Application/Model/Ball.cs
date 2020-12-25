
using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Model
{
    public class Ball
    {
        public Ball()
        {
            CurrentY = GameDefaults.BallStartY;
            CurrentX = GameDefaults.BallStartX;
            DirectionX = GameDefaults.BallDirectionX;
            DirectionY = GameDefaults.BallDirectionY;
            Symbol = GameDefaults.BallSymbol;
        }
        
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public bool DirectionX { get; set; }
        public bool DirectionY { get; set; }
        public char Symbol { get; set; }
    }
}
