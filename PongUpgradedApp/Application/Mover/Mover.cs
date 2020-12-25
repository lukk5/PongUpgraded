namespace PongUpgraded.Application.Mover
{
    public class Mover : IMover // RECEIVER
    {
        public int Action(bool isUp) => isUp ? -1 : 1;
    }
}
