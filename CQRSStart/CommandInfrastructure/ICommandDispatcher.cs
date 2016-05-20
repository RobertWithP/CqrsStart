namespace CQRSStart.CommandInfrastructure
{
	public interface ICommandDispatcher
	{
		void Execute<TCommand>(TCommand command) where TCommand : ICommand;
	}
}