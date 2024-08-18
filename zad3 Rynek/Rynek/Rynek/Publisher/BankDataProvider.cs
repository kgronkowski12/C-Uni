using System;
using System.Collections.Generic;

namespace IObserverNet40.Publisher
{
	public class BankDataProvider : IObservable<BankData>
	{
		List<IObserver<BankData>> observers;

		public BankDataProvider()
		{
			observers = new List<IObserver<BankData>>();
		}

		public IDisposable Subscribe(IObserver<BankData> observer)
		{
			if (!observers.Contains(observer))
			{
				observers.Add(observer);
			}
			return new UnSubscriber(observers, observer);
		}

		private void InflationChanged(float inf)
		{
			foreach (var obs in observers)
			{
				obs.OnNext(new BankData(inf));
			}
		}

		public void SetInflation(float inf)
		{
			InflationChanged(inf);
		}
	}
}
