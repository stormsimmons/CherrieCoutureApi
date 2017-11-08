using CherrieCouture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherrieCouture.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
		IList<ShoppingCart> List();
		ShoppingCart GetShoppingCart(string username);

		void Update(string username , ShoppingCart shoppingCart);
		void Delete(string username);
		void Insert(ShoppingCart shoppingCart); 
    }
}
