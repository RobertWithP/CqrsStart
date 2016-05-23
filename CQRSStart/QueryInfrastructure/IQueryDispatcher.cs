namespace CQRSStart.QueryInfrastructure
{
	public interface IQueryDispatcher
	{
		TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}