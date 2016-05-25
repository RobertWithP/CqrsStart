namespace CQRSStart.CommandInfrastructure
{
	using System;

	using CQRSStart.Infrastructure;

	using TypeC;

	public class MessageDispatcher : IMessageDispatcher
	{
		private readonly TypeContainer instanceResolver;

		public MessageDispatcher()
		{
			this.instanceResolver = TypeContainer.Instance;
		}

		public void ExecuteCommand<TCommand>(TCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			var handler = this.instanceResolver.GetInstance<IHandleCommand<TCommand>>();

			if (handler == null)
			{
				throw new ArgumentException(typeof(TCommand).ToString());
			}
			
			var resultEvents = handler.Execute(command);

			foreach (var @event in resultEvents)
			{
				this.PublishEvent(@event);
			}
		}

		public void PublishEvent(object eventToPublish)
		{
			var handler = this.instanceResolver.GetInstance<ISubscribeTo<eve>>();

			if (handler == null)
			{
				throw new ArgumentException(typeof(TEvent).ToString());
			}

			handler.Handle(eventToPublish);
		}
	}
}