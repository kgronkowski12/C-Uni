using System;
using ShoppingCart.Visitors;

namespace ShoppingCart.Data
{
	public class Przedmiot : CartItem
	{
		public int CenaProducenta { get; set; }
		public int Price { get; set; }
		public String Nazwa { get; set; }
		public bool PierwszaPotrzeba { get; set; }

		public int ilość{ get; set; }
        public int dostawa{ get; set; }

        public int Marża{ get; set; }

        public Przedmiot(int price, string nazwa, bool potrzeba, int M,int dost)
		{
			CenaProducenta = price;
			Nazwa = nazwa;
			PierwszaPotrzeba = potrzeba;
			Price = CenaProducenta;
			dostawa = dost;
			Marża = M;
		}
		public int Accept(ShoppingCartVisitor visitor) => visitor.Visit(this);
	}
}
