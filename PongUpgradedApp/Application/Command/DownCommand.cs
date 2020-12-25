using PongUpgraded.Application.Mover;

namespace PongUpgraded.Application.Command
{
    public class DownCommand : ICommand
    {
        private readonly IMover _mover;
        
        public DownCommand(IMover mover)
        {
            _mover = mover;
        }
        
        public int Execute()
        {
            return _mover.Action(false);
        }
    }
}
