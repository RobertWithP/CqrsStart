namespace CQRSStart
{
	using System.Collections.Generic;

	using CQRSStart.CommandInfrastructure;
	using CQRSStart.Commands;

	using System;

	class Program
	{
		private static CommandDispatcher commandDispatcher;

		static void Main(string[] args)
		{
			InitSystem();

			Console.WriteLine("Available commands: AddNew, Quit");

			while (true)
			{
				string command = Console.ReadLine();

				if (IsQuitCall(command))
				{
					Console.WriteLine("Quit is called. Shutdown system ....");
					break;
				}

				ParseAndRunCommand(command);
			}

			Console.ReadKey();
		}

		private static void InitSystem()
		{
			var commandHandler = new Dictionary<string, ICommandHandler<ICommand>>();
		
			// add all commandhandler from hand
			commandHandler.Add(typeof(AddNew).Name, new AddNewCommandHandler());
			
			commandDispatcher = new CommandDispatcher(commandHandler);
		}

		private static bool IsQuitCall(string command)
		{
			return command.Equals("quit", StringComparison.OrdinalIgnoreCase);
		}

		private static void ParseAndRunCommand(string command)
		{
			switch (command.Trim().ToLower())
			{
				case "addnew":
					AddNew();
					return;
				default:
					return;		
			}			
		}

		/// <summary>
		/// Add new "thing" to the system.
		/// </summary>
		private static void AddNew()
		{
			commandDispatcher.Execute(new AddNew());
		}
	}
}
