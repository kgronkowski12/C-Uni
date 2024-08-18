using IObserverNet40;
using IObserverNet40.Publisher;
using ShoppingCart;
using ShoppingCart.Data;
using ShoppingCart.Visitors;
using System.Runtime.InteropServices;

namespace Rynek
{
    public class Ryneksy
    {
        List<Sprzedawca> sprzedawcy = new List<Sprzedawca>();
        List<Klient> klienci = new List<Klient>();
        public Sprzedawca returnSprz()
        {
            return sprzedawcy[0];
        }

        public void nextTurn()
        {

            foreach (Klient k in klienci)
            {
                k.Kup(sprzedawcy);
            }
            foreach (Sprzedawca x in sprzedawcy)
            {
                Console.WriteLine("-Oferta sprzedawcy-");
                foreach (Przedmiot p in x.oferta)
                {
                    x.Visit(p);
                    Console.WriteLine(p.Nazwa + " " + p.Price + " w il " + p.ilość);
                }
            }
        }
        public static void Main(string[] args)
        {
            List<Sprzedawca> sprzedawcy = new List<Sprzedawca>();
            List<Klient> klienci = new List<Klient>();

            Random rnd = new Random();
            BankDataProvider bank = new BankDataProvider();
            for (int i = 0; i <= 9; i++)
            {
                Sprzedawca sprzedawca = new Sprzedawca(bank);
                sprzedawca.oferta.Add(new Przedmiot(30+ rnd.Next()%20, "Chleb", true, rnd.Next() % 30+10, rnd.Next()%20+5));
                sprzedawca.oferta.Add(new Przedmiot(30+ rnd.Next()%20, "Woda", true, rnd.Next() % 20 + 5, rnd.Next() % 20 + 5));
                sprzedawca.oferta.Add(new Przedmiot(400+ rnd.Next() % 300, "Telewizor", false, 100+rnd.Next() % 400, rnd.Next() % 2+1));
                sprzedawcy.Add(sprzedawca);
            }  
            for (int i = 0; i < 600; i++)
            {
                Klient klient = new Klient(bank);
                klient.wpływy = 300 + rnd.Next() % 200;
                klienci.Add(klient);
            }
            bank.SetInflation(7);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("\n\nTura "+(i+1)+"\n\n");

                bank.SetInflation(rnd.Next() % 15);

                foreach (Klient k in klienci)
                {
                    k.Kup(sprzedawcy);
                }
                foreach (Sprzedawca x in sprzedawcy)
                {
                        Console.WriteLine("-Oferta sprzedawcy-");
                    foreach (Przedmiot p in x.oferta)
                    {
                        x.Visit(p);
                        Console.WriteLine(p.Nazwa + " " + p.Price+" w il "+p.ilość);
                    }
                }
            }
        }
    }
}