namespace PongUpgraded.Application.Command
{
    public class Invoker : IInvoker
    {
        public int ExecuteCommand(ICommand command)
        {
            return command?.Execute() ?? 0;
            
        }
    }
}
