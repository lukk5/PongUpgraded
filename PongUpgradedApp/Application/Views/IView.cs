using PongUpgraded.Application.Model;

namespace PongUpgraded.Application.Views
{
    public interface IView
    {
        void ShowStartScreen();
        void Refresh(GameModel model);
        void Clear();
    }
}