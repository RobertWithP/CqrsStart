namespace CQRSStart.CommandInfrastructure
{
	using System.Collections;

	public interface IHandleCommand<TCommand>
	{	
		IEnumerable Execute(TCommand command);
	}
}