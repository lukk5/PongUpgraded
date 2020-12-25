using NUnit.Framework;
using PongUpgraded.Application.Logic;
using PongUpgraded.Application.Model;

namespace UnitTests
{
    public class MovingLogicTests
    {
        private const int DefaultScore = 0;
        
        private MovingLogic _movingLogic;
        
        [SetUp]
        public void Setup()
        {
            _movingLogic = new MovingLogic();
        }

        [TestCase(9999, false)]
        [TestCase(10, true)]
        [TestCase(28, true)]
        [TestCase(0, true)]
        public void TestIsCorrectMovePlayer(int moveTo, bool expected)
        {
            var result = _movingLogic.IsCorrectMovePlayer(moveTo);
            
            Assert.AreEqual(expected, result);
        }

        [TestCase(false, 5, 2, 0, 0, 1)]
        [TestCase(false, 5, 5, 0, 0, 0)]
        [TestCase(true, 5, 0, 2, 1, 0)]
        [TestCase(true, 5, 0, 5, 0, 0)]
        public void TestGivePoint(bool ballDirection,
            int ballY,
            int firstPlayerY,
            int secondPlayerY,
            int firstPlayerExpectedResult,
            int secondPlayerExpectedResult)
        {
            var gameModel = new GameModel
            {
                Ball = new Ball
                {
                    DirectionX = ballDirection,
                    CurrentY = ballY
                },
                FirstPlayer = new FirstPlayer
                {
                    CurrentY = firstPlayerY,
                    Score = DefaultScore
                },
                SecondPlayer = new SecondPlayer
                {
                    CurrentY = secondPlayerY,
                    Score = DefaultScore
                }
            };

            _movingLogic.GivePoint(gameModel);
            
            Assert.AreEqual(firstPlayerExpectedResult, gameModel.FirstPlayer.Score);
            Assert.AreEqual(secondPlayerExpectedResult, gameModel.SecondPlayer.Score);
        }

        [TestCase(9999,9999, false)]
        [TestCase(10,10, true)]
        [TestCase(28,45, false)]
        [TestCase(0,0, false)]
        [TestCase(45,25, true)]
        public void TestIsCorrectMoveBall(int moveToX, int moveToY, bool expected)
        {
            var result = _movingLogic.IsCorrectMoveBall(moveToX, moveToY);

            Assert.AreEqual(expected, result);
        }

        [TestCase(true,false)]
        [TestCase(false,true)]
        public void TestIsBallDirectionWillChangeX(bool ballDirectionX, bool expected)
        {
            var gameModel = new GameModel
            {
               Ball = new Ball {
                DirectionX = ballDirectionX
               }
            };

             _movingLogic.ChangeBallDirectionX(gameModel);

             var result = gameModel.Ball.DirectionX;
             
             Assert.AreEqual(expected,result);

        }


        [TestCase(true, false)]
        [TestCase(false, true)]
        public void TestIsBallDirectionWillChangeY(bool ballDirectionY, bool expected)
        {
            var gameModel = new GameModel
            {
                Ball = new Ball
                {
                    DirectionY = ballDirectionY
                }
            };

            _movingLogic.ChangeBallDirectionY(gameModel);

            var result = gameModel.Ball.DirectionY;

            Assert.AreEqual(expected, result);
        }

    }
}