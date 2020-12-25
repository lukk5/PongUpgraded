using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PongUpgraded.Application.Command;
using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;
using PongUpgraded.Application.Mover;
using PongUpgraded.Application.Observer;
using PongUpgraded.Application.Settings;
using PongUpgraded.Application.Views;

namespace PongUpgraded
{
    public class GamePresenter : IHostedService, IDisposable
    {
        private readonly IInvoker _invoker;
        private readonly IMover _mover;
        private readonly IView _view;
        private readonly IMovingLogic _logic;
        private ICommand _command;
        private readonly GameModel _gameModel;

        private readonly ObserverHitWall _observerHitWall = new();
        private readonly ObserverHitPlayer _observerHitPlayer = new();
        private readonly ObserverMissShot _observerMissShot = new();
        public GamePresenter(IInvoker invoker,IMover mover, IView view, IMovingLogic logic)
        {
            _invoker = invoker;
            _gameModel = new();
            _mover = mover;
            _view = view;
            _logic = logic;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            ShowStartScreen();
            SetupObservers();

            while (!IsGameOver())
            {
                MoveFirstPlayer();
                MoveSecondPlayer();
                MoveBall();
                UpdateView();

            }
            
            ReleaseObservers();
            Clear();
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Clear();
            return Task.CompletedTask;
        }

        private void SetupObservers()
        {

            _logic.Attach(_observerHitWall);
            _logic.Attach(_observerHitPlayer);
            _logic.Attach(_observerMissShot);

        }

        private void ReleaseObservers()
        {
            _logic.Detach(_observerHitWall);
            _logic.Detach(_observerHitPlayer);
            _logic.Detach(_observerMissShot);
        }

        private void MoveFirstPlayer()
        {
            var movement = GetFirstPlayerMovement();
            
            if (_logic.IsCorrectMovePlayer(_gameModel.FirstPlayer.CurrentY + movement))
            {
                _gameModel.FirstPlayer.CurrentY += movement;
            }
        }
        private void MoveBall()
        {
            var (movementX, movementY) = GetBallMovement();

            _logic.CheckDirectionChanges(movementX, movementY, _gameModel);

            if (!_logic.IsCorrectMoveBall(movementX+_gameModel.Ball.CurrentX, movementY+_gameModel.Ball.CurrentY)) return;
            _gameModel.Ball.CurrentX += movementX;
            _gameModel.Ball.CurrentY += movementY;
        }
        
        private void MoveSecondPlayer()
        {
            var movement = GetSecondPlayerMovement();
            
            if (_logic.IsCorrectMovePlayer(_gameModel.SecondPlayer.CurrentY + movement))
            {
                _gameModel.SecondPlayer.CurrentY += movement;
            }
        }
        private bool IsGameOver()
        {
            return _gameModel.SecondPlayer.Score == GameDefaults.MaxScoreForLose || _gameModel.FirstPlayer.Score == GameDefaults.MaxScoreForLose;
        }
        private void UpdateView()
        {
            _view.Refresh(_gameModel);
        }

        private void Clear()
        {
            _view.Clear();
        }
        private void ShowStartScreen()
        {
            _view.ShowStartScreen();
        }
        public int GetSecondPlayerMovement()
        {
            var currentBallY = _gameModel.Ball.CurrentY;

            var directionY = _gameModel.Ball.DirectionY;

            var currentPcY = _gameModel.SecondPlayer.CurrentY;

            Random rand = new();

            var possibility = rand.Next(GameDefaults.GameLevel3);
            
            if (possibility < GameDefaults.Possibility) return 0;
            var movement = currentBallY - currentPcY;
            if (directionY)
            {
                movement = Math.Abs(movement);
            }
            else
            {
                movement = Math.Abs(movement) * -1;
            }
            return movement;
        }

        public int GetFirstPlayerMovement()
        {
                _command = Console.KeyAvailable
                ? Console.ReadKey().Key switch
                {
                    ConsoleKey.UpArrow => new UpCommand(_mover),
                    ConsoleKey.DownArrow => new DownCommand(_mover),
                    _ => null
                }
                : null;
      
            var movement = _invoker.ExecuteCommand(_command);

            return movement;
        }

        public Tuple<int,int> GetBallMovement()
        {
            int x = 0, y = 0;

            if (_gameModel.Ball.DirectionX&& _gameModel.Ball.DirectionY)
            {
                x = 1;
                y = 1;
            }
            else if (!_gameModel.Ball.DirectionX && !_gameModel.Ball.DirectionY)
            {
                x = -1;
                y = -1;
            }

            if (_gameModel.Ball.DirectionX&& !_gameModel.Ball.DirectionY)
            {
                x = 1;
                y = -1;
            }
            else if (!_gameModel.Ball.DirectionX && _gameModel.Ball.DirectionY)
            {
                x = -1;
                y = 1;
            }

            return Tuple.Create(x, y);
        }
        public void Dispose()
        {

        }
    }
}