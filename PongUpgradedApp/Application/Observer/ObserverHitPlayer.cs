using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;

namespace PongUpgraded.Application.Observer
{
    public class ObserverHitPlayer : IObserver
    {
        public void Update(IMovingLogic logic, GameModel model)
        {
            if (!logic.StateHitPlayer) return;
            logic.ChangeBallDirectionX(model);
            logic.StateHitPlayer = false;
        }
    }
}
