using System;
using System.Threading;
using System.Timers;
using PongUpgraded.Application.ConsoleKey;
using PongUpgraded.Application.Model;
using PongUpgraded.Application.Settings;

namespace PongUpgraded.Application.Views
{
    public class View : IView
    {

        public View()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Console.SetWindowSize(GameDefaults.MaxSizeX + 1, GameDefaults.MaxSizeY + 10);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.Title = "PONG V2";
        }

        public void ShowStartScreen()
        {
            Console.Clear();
            Console.Out.WriteLine("------------------ PONG v2 ------------------");
            Console.Out.WriteLine();
            Console.Out.WriteLine("Press enter to start the game..");
            ConsoleKeyPress.WaitFor(System.ConsoleKey.Enter);
        }

        public void Refresh(GameModel model)
        {
            Console.Clear();

            Console.SetCursorPosition(GameDefaults.MaxSizeX, model.SecondPlayer.CurrentY);
            Console.Out.Write(model.SecondPlayer.Symbol);

            Console.SetCursorPosition(GameDefaults.MaxSizeX, model.SecondPlayer.CurrentY + 1);
            Console.Out.Write(model.SecondPlayer.Symbol);

            Console.SetCursorPosition(GameDefaults.MinSizeX, model.FirstPlayer.CurrentY + 1);
            Console.Out.Write(model.FirstPlayer.Symbol);

            Console.SetCursorPosition(GameDefaults.MinSizeX, model.FirstPlayer.CurrentY);
            Console.Out.Write(model.FirstPlayer.Symbol);

            Console.SetCursorPosition(model.Ball.CurrentX, model.Ball.CurrentY);
            Console.Out.Write(model.Ball.Symbol);

            PrintScore(model);
            SlowDown();
        }

        private void PrintScore(GameModel model)
        {
            Console.SetCursorPosition(GameDefaults.ScoreX, GameDefaults.ScoreY);
            var score = model.FirstPlayer.Score.ToString() + " - " + model.SecondPlayer.Score.ToString();
            Console.Out.Write(score);
        }

        public void Clear()
        {
            Console.Clear();
        }

        private void SlowDown()
        {
            Thread.Sleep(GameDefaults.SlowDownTime);
        }
    }
}
