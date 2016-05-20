namespace CQRSStart.CommandInfrastructure
{
	public interface ICommandHandler<out TCommand> where TCommand : ICommand
	{
		void Execute(ICommand command);
	}
}