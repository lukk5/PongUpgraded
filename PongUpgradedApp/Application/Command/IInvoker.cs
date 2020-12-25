namespace PongUpgraded.Application.Command
{
    public interface IInvoker
    {
        int ExecuteCommand(ICommand command);
    }
}