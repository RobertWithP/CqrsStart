namespace CQRSStart
{
	using System.Collections.Generic;

	using CQRSStart.CommandInfrastructure;
	using CQRSStart.Commands;

	using System;

	using TypeC;

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
			TypeContainer typeC = TypeContainer.Instance;
			typeC.Register<ICommandHandler<AddNew>, AddNewHandler>();
			
			commandDispatcher = new CommandDispatcher();
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
