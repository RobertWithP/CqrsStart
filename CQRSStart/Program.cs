namespace CQRSStart
{
	using System.Collections.Generic;

	using CQRSStart.CommandInfrastructure;
	using CQRSStart.Commands;

	using System;

	using CQRSStart.Queries;
	using CQRSStart.QueryInfrastructure;

	using TypeC;

	class Program
	{
		private static CommandDispatcher commandDispatcher;

		private static QueryDispatcher queryDispatcher;

		static void Main(string[] args)
		{
			InitSystem();

			Console.WriteLine("Available commands: AddNew, GetAll, Quit");

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

			// register command handler
			typeC.Register<IHandleCommand<AddNew>, AddNewHandler>();
			
			// register query handler
			typeC.Register<IQueryHandler<GetAllThings, IEnumerable<Model.Thing>>, GetAllThingsHandler>();

			commandDispatcher = new CommandDispatcher();
			queryDispatcher = new QueryDispatcher();
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
				case "getall":
					GetAll();
					return;
				default:
					return;		
			}			
		}

		private static void GetAll()
		{
			Console.WriteLine("Query for all things:");

			var result = queryDispatcher.Execute<GetAllThings, IEnumerable<Model.Thing>>(new GetAllThings());
			foreach (var thing in result)
			{
				Console.WriteLine(thing.ToString());
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
