namespace PongUpgraded.Application.Model
{
    public class GameModel
    {
        public GameModel()
        {
            FirstPlayer = new FirstPlayer();
            SecondPlayer = new SecondPlayer();
            Ball = new Ball();
        }
        public FirstPlayer FirstPlayer { get; set; }
        
        public SecondPlayer SecondPlayer { get; set; }

        public Ball Ball { get; set; }
    }
}
