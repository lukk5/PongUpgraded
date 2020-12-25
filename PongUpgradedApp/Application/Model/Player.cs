
using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Model
{
    public abstract class Player
    {
        protected Player()
        {
            Score = 0;
            CurrentY = GameDefaults.StartY;
        }
        
        public int CurrentY { get; set; }
        public int Score { get; set; }
        public int CurrentX { get; set; }
    }
}
