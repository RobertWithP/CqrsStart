﻿namespace CQRSStart.CommandInfrastructure
{
	using System;

	using TypeC;

	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly TypeContainer instanceResolver;

		public CommandDispatcher()
		{
			this.instanceResolver = TypeContainer.Instance;
		}

		public void Execute<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			var handler = this.instanceResolver.GetInstance<ICommandHandler<TCommand>>();

			if (handler == null)
			{
				throw new ArgumentException(typeof(TCommand).ToString());
			}
			
			handler.Execute(command);
		}
	}
}