
using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Model
{
    public class FirstPlayer : Player
    {
        public FirstPlayer()
        {
            CurrentX = GameDefaults.MinSizeX;
        }
        public virtual char Symbol => GameDefaults.FirstPlayerSymbol;
    }
}
