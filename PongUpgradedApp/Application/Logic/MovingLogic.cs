
using System;
using System.Collections.Generic;
using PongUpgraded.Application.Model;
using PongUpgraded.Application.Observer;
using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Logic
{
    public class MovingLogic : IMovingLogic 
    {
        private readonly List<IObserver> _observers;

        public MovingLogic()
        {
             _observers = new();
        }
        public bool StateHitPlayer { get; set; }

        public bool StateHitWall { get; set; }
        
        public bool StateMissShot { get; set; }

        public bool IsCorrectMovePlayer(int movementToY)
        {
            return  (movementToY <= GameDefaults.MaxSizeY &&
                     movementToY >= GameDefaults.MinSizeY);
        }
        public bool IsCorrectMoveBall(int movementToX, int movementToY)
        {
            return ( movementToX <= GameDefaults.MaxSizeX &&
                     movementToX >= GameDefaults.MinSizeX) &&
                   ( movementToY <= GameDefaults.MaxSizeY &&
                     movementToY >= GameDefaults.MinSizeY);
        }

        public void CheckDirectionChanges(int movementToX, int movementToY, GameModel gameModel)
        {
            var currentY = gameModel.Ball.CurrentY;
            var directionX = gameModel.Ball.DirectionX;
            var directionY = gameModel.Ball.DirectionY;

            switch (directionY)
            {
                case false when movementToY + currentY == GameDefaults.MinSizeY:
                case true when movementToY + currentY == GameDefaults.MaxSizeY:
                    StateHitWall = true;
                    break;
            }

            if (!directionX)
            {
                CheckFirstPlayerHit(gameModel,movementToY);
            }
            else
            {
                CheckSecondPlayerHit(gameModel,movementToY);
            }
            
            Notify(gameModel);
        }
        private void CheckFirstPlayerHit(GameModel gameModel, int movementToY)
        {
            var currentX = gameModel.Ball.CurrentX;
            var currentY = gameModel.Ball.CurrentY;

            if (Math.Abs(gameModel.FirstPlayer.CurrentY - currentY + movementToY) <= 2 &&
                gameModel.FirstPlayer.CurrentX == currentX - 1)
            {
                StateHitPlayer = true;

            }
            else if (gameModel.FirstPlayer.CurrentX == currentX)
            {
                StateMissShot = true;
            }
        }
        
        private void CheckSecondPlayerHit(GameModel gameModel, int movementToY)
        {
            var currentX = gameModel.Ball.CurrentX;
            var currentY = gameModel.Ball.CurrentY;

            if (Math.Abs(gameModel.SecondPlayer.CurrentY - currentY + movementToY) <= 2 &&
                gameModel.SecondPlayer.CurrentX == currentX + 1)
            {
                StateHitPlayer = true;

            }
            else if (gameModel.SecondPlayer.CurrentX == currentX)
            {
                StateMissShot = true;
            }
        }
        
        public void ChangeBallDirectionX(GameModel gameModel)
        {
            gameModel.Ball.DirectionX = !gameModel.Ball.DirectionX;
        }

        public void ChangeBallDirectionY(GameModel gameModel)
        {
            gameModel.Ball.DirectionY = !gameModel.Ball.DirectionY;
        }

        public void GivePoint(GameModel gameModel)
        {
            switch (gameModel.Ball.DirectionX)
            {
                case false when gameModel.Ball.CurrentY != gameModel.FirstPlayer.CurrentY:
                    gameModel.SecondPlayer.Score++;
                    break;
                case true when gameModel.Ball.CurrentY != gameModel.SecondPlayer.CurrentY:
                    gameModel.FirstPlayer.Score++;
                    break;
            }
            
            SetStart(gameModel);
            ChangeBallDirectionX(gameModel);

        }
        private void Notify(GameModel gameModel)
        {
            foreach (var observer in _observers)
            {
                observer.Update(this, gameModel);
            }
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        private void SetStart(GameModel gameModel)
        {
            gameModel.Ball.CurrentX = GameDefaults.BallStartX;
            gameModel.Ball.CurrentY = GameDefaults.BallStartY;

            gameModel.FirstPlayer.CurrentY = GameDefaults.StartY;
            gameModel.SecondPlayer.CurrentY = GameDefaults.StartY;
        }
    }
}
