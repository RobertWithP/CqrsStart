namespace CQRSStart.CommandInfrastructure
{
	public interface IMessageDispatcher
	{
		void ExecuteCommand<TCommand>(TCommand command);

		void PublishEvent(object eventToPublish);
	}
}