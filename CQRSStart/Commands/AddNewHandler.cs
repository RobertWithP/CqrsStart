namespace CQRSStart.Commands
{
	using System;

	using CQRSStart.CommandInfrastructure;

	public class AddNewHandler : ICommandHandler<AddNew>
	{
		public void Execute(ICommand command)
		{
			Console.WriteLine("AddNew is called....");
		}
	}
}