namespace CQRSStart.Commands
{
	using System;

	using CQRSStart.CommandInfrastructure;

	public class AddNewHandler : IHandleCommand<AddNew>
	{
		public void Execute(AddNew command)
		{
			Console.WriteLine("AddNew is called....");
		}
	}
}