using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;

namespace PongUpgraded.Application.Observer
{
    public interface IObserver
    {
        void Update(IMovingLogic logic, GameModel model);
    }
}
