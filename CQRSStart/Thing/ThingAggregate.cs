namespace CQRSStart.Thing
{
	using System;
	using System.Collections;

	using CQRSStart.CommandInfrastructure;
	using CQRSStart.Events;
	using CQRSStart.Infrastructure;

	public class ThingAggregate : Aggregate, IHandleCommand<NewThing>
	{
		public IEnumerable Execute(NewThing command)
		{
			Console.WriteLine("NewThing is called ...");
			yield return new ThingCreated();
		}
	}
}