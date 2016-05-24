namespace CQRSStart.CommandInfrastructure
{
	public interface IHandleCommand<TCommand>
	{	
		void Execute(TCommand command);
	}
}