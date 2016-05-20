namespace CQRSStart.CommandInfrastructure
{
	using System;
	using System.Collections.Generic;

	public class CommandDispatcher : ICommandDispatcher
	{

		private readonly Dictionary<string, ICommandHandler<ICommand>> commandHandlers;

		public CommandDispatcher(Dictionary<string, ICommandHandler<ICommand>> commandHandlers)
		{
			this.commandHandlers = commandHandlers;
		}

		public void Execute<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			if (!commandHandlers.ContainsKey(command.GetType().Name))
			{
				throw new KeyNotFoundException(command.GetType().ToString());
			}

			commandHandlers[command.GetType().Name].Execute(command);
		}
	}
}