namespace CQRSStart.Queries
{
	using System.Collections.Generic;

	using CQRSStart.Model;
	using CQRSStart.QueryInfrastructure;

	public class GetAllThingsHandler : IQueryHandler<GetAllThings, IEnumerable<Thing>>
	{
		public IEnumerable<Thing> Execute(GetAllThings query)
		{
			yield return new Thing();
		}
	}
}