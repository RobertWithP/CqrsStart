namespace CQRSStart.Thing
{
	using System;

	using CQRSStart.CommandInfrastructure;

	public class ThingAggregate : IHandleCommand<NewThing>
	{
		public void Execute(NewThing command)
		{
			Console.WriteLine("NewThing is called ...");
		}
	}
}