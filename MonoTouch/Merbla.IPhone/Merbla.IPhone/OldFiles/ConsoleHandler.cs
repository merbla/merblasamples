using System;
using Merbla.IPhone;
namespace Merbla.IPhone
{
 
	
	public class ConsoleHandler :IHandle<MovementFinished>
	{
		private readonly IEventAggregator _aggregator;
		
		public ConsoleHandler (IEventAggregator aggregator)
		{
			_aggregator = aggregator;
			_aggregator.Subscribe(this);
		}
		
		public void HandleEvent(MovementFinished message)
		{
			Console.WriteLine("Movement finished" + message.FinishDateTime.ToLongDateString());
		}
		
	}
}

