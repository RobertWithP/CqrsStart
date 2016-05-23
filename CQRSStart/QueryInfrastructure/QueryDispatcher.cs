namespace CQRSStart.QueryInfrastructure
{
	using System;

	using TypeC;

	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly TypeContainer instanceResolver;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		public QueryDispatcher()
		{
			this.instanceResolver = TypeContainer.Instance;
		}

		public TResult Execute<TQuery, TResult>(TQuery query)
				where TQuery : IQuery<TResult>
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}

			var handler = this.instanceResolver.GetInstance<IQueryHandler<TQuery, TResult>>();

			if (handler == null)
			{
				throw new NotImplementedException(typeof(TQuery).ToString());
			}

			return handler.Execute(query);
		}
	}
}