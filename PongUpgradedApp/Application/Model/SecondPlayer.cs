using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Model
{
    public class SecondPlayer : Player
    {
        public SecondPlayer()
        {
            CurrentX = GameDefaults.MaxSizeX;
        }

        public virtual char Symbol => GameDefaults.SecondPlayerSymbol;
    }
}
