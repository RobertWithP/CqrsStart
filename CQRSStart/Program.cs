namespace CQRSStart
{
	using System.Collections.Generic;

	using CQRSStart.CommandInfrastructure;

	using System;

	using CQRSStart.Events;
	using CQRSStart.Infrastructure;
	using CQRSStart.Queries;
	using CQRSStart.QueryInfrastructure;
	using CQRSStart.Thing;

	using TypeC;

	class Program  : ISubscribeTo<ThingCreated>
	{
		private static MessageDispatcher commandDispatcher;

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
			typeC.Register<IHandleCommand<NewThing>, ThingAggregate>();
			
			// register event handler
			typeC.Register<ISubscribeTo<ThingCreated>, Program>();

			// register query handler
			typeC.Register<IQueryHandler<GetAllThings, IEnumerable<Model.Thing>>, GetAllThingsHandler>();

			commandDispatcher = new MessageDispatcher();
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
			commandDispatcher.ExecuteCommand(new NewThing());
		}

		public void Handle(ThingCreated e)
		{
			Console.WriteLine("A thing was created!");
		}
	}
}
