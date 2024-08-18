using ShoppingCart.Data;

namespace ShoppingCart.Visitors
{
	public interface ShoppingCartVisitor
	{
		int Visit(Przedmiot book);
	}
}
