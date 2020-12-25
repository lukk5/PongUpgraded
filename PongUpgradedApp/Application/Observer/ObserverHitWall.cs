using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;

namespace PongUpgraded.Application.Observer
{
    public class ObserverHitWall : IObserver
    {
        public void Update(IMovingLogic logic, GameModel model)
        {
            if (!logic.StateHitWall) return;
            logic.ChangeBallDirectionY(model);
            logic.StateHitWall = false;
        }
    }
}