using PongUpgraded.Application.Model;
using PongUpgraded.Application.Observer;

namespace PongUpgraded.Application.Logic
{
    public interface IMovingLogic
    {
        bool StateHitPlayer { get; set; }
        bool StateHitWall { get; set; }

        bool StateMissShot { get; set; }
        
        bool IsCorrectMovePlayer(int moveToY);

        bool IsCorrectMoveBall(int moveToX, int moveToY);
        void CheckDirectionChanges(int moveToX, int moveToY, GameModel model);

        // ReSharper disable once IdentifierTypo
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        
        void GivePoint(GameModel model);

        void ChangeBallDirectionX(GameModel model);

        void ChangeBallDirectionY(GameModel model);

    }
}