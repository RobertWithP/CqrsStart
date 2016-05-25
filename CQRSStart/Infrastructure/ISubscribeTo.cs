namespace CQRSStart.Infrastructure
{
	public interface ISubscribeTo<TEvent>
	{
		void Handle(TEvent e);
	}
}