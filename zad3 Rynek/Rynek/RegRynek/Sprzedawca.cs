using System;
using IObserverNet40.Publisher;
using ShoppingCart;
using ShoppingCart.Data;
using ShoppingCart.Visitors;

public class Sprzedawca : IObserver<BankData> , ShoppingCartVisitor
{

    public BankData Data { get; set; }
	public List<Przedmiot> oferta = new List<Przedmiot>();
	private IDisposable _unsubscriber;

	public Sprzedawca()
	{
	}
	public Sprzedawca(IObservable<BankData> provider)
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

	public int Visit(Przedmiot przedmiot)
	{
		przedmiot.ilość += przedmiot.dostawa;
		przedmiot.Price = (przedmiot.CenaProducenta + przedmiot.Marża);
		float multiply = 0.2F;
		if (przedmiot.ilość!=0)
			 multiply = przedmiot.dostawa / przedmiot.ilość;
		if (multiply > 5)
			multiply = 5;
		if (multiply < 0.2)
			multiply = 0.2F;
		przedmiot.Price = (int)(przedmiot.Price * multiply);
		przedmiot.CenaProducenta = (int)(przedmiot.CenaProducenta * (100 + Data.Inflacja) / 100);
		return przedmiot.Price;
	}
}
