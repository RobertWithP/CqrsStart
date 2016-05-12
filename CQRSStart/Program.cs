using System;

namespace CQRSStart
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Available commands: Get, Quit");

			while (true)
			{
				string command = Console.ReadLine();

				if (IsQuitCommand(command))
				{
					Console.WriteLine("Quit is called. Shutdown system ....");
					break;
				}

				RunCommand(command);
			}

			Console.ReadKey();
		}

		private static void RunCommand(string command)
		{
			switch (command.Trim().ToLower())
			{
				case "get":
					GetAllData();
					return;
				default:
					return;		
			}			
		}

		private static void GetAllData()
		{
			Console.WriteLine("Call --> Get all data.");

		}

		private static bool IsQuitCommand(string command)
		{
			return command.Equals("quit", StringComparison.OrdinalIgnoreCase);
		}
	}
}
