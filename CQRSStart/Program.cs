using System;

namespace CQRSStart
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Available commands: AddNew, Quit");

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
				case "addnew":
					
					return;
				default:
					return;		
			}			
		}

		private static bool IsQuitCommand(string command)
		{
			return command.Equals("quit", StringComparison.OrdinalIgnoreCase);
		}
	}
}
