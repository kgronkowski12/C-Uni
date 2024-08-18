using System;
using IObserverNet40.Publisher;

namespace IObserverNet40.Subscriber
{
	class BankSubscriber : IObserver<BankData>
	{
		public BankData Data { get; set; }
		private IDisposable _unsubscriber;

		public BankSubscriber()
		{
		}
		public BankSubscriber(IObservable<BankData> provider)
		{
			_unsubscriber = provider.Subscribe(this);
		}

		public void Subscribe(IObservable<BankData> provider)
		{
			if (_unsubscriber == null)
			{
				_unsubscriber = provider.Subscribe(this);
			}
		}

		public void Unsubscribe()
		{
			_unsubscriber.Dispose();
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(BankData value)
		{
			this.Data = value;
		}
	}
}
