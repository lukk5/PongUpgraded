using PongUpgraded.Application.Mover;

namespace PongUpgraded.Application.Command
{
    public class UpCommand : ICommand
    {
        private readonly IMover _mover;

        public UpCommand(IMover mover)
        {
            _mover = mover;
        }
        
        public int Execute()
        {
            return _mover.Action(true);
        }
    }
}
