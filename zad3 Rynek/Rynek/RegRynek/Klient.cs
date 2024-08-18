using System;
using IObserverNet40.Publisher;
using ShoppingCart;
using ShoppingCart.Data;
using ShoppingCart.Visitors;

public class Klient : IObserver<BankData>
{

    public BankData Data { get; set; }
	public int wpływy { get; set; }
	public int pieniądze;
	public List<Przedmiot> oferta = new List<Przedmiot>();
	private IDisposable _unsubscriber;

	public Klient()
	{
	}
	public Klient(IObservable<BankData> provider)
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
	public void Kup(List<Sprzedawca> sprzedawcy)
	{
        wpływy = (int)(wpływy * (100 + Data.Inflacja) / 100);
        pieniądze += wpływy;
        int najt = 0;
        int najtID = 0;
        for (int n = 0; n < sprzedawcy[0].oferta.Count; n++)
        {
            for (int z = 0; z < sprzedawcy.Count; z++)
            {
                if ((najt == 0 && sprzedawcy[z].oferta[n].ilość >= 1) || (sprzedawcy[z].oferta[n].Price < najt && sprzedawcy[z].oferta[n].ilość >= 1))
                {
                    najtID = z;
                }
            }
            if (sprzedawcy[najtID].oferta[n].PierwszaPotrzeba)
            {
                if (pieniądze > sprzedawcy[najtID].oferta[n].Price && sprzedawcy[najtID].oferta[n].ilość >= 1)
                {
                    sprzedawcy[najtID].oferta[n].ilość -= 1;
                    pieniądze -= sprzedawcy[najtID].oferta[n].Price;
                }
            }
            else
            {
                if (pieniądze > sprzedawcy[najtID].oferta[n].Price * 3 && sprzedawcy[najtID].oferta[n].ilość >= 1)
                {
                    sprzedawcy[najtID].oferta[n].ilość -= 1;
                    pieniądze -= sprzedawcy[najtID].oferta[n].Price;
                }
            }
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
