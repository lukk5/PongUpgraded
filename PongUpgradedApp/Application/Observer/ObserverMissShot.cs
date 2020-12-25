using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;

namespace PongUpgraded.Application.Observer
{
    public class ObserverMissShot : IObserver
    {
        public void Update(IMovingLogic logic, GameModel model)
        {
            if (!logic.StateMissShot) return;
            logic.GivePoint(model);
            logic.StateMissShot = false;
        }
    }
}
