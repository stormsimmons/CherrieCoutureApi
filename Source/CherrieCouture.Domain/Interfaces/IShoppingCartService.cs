using CherrieCouture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherrieCouture.Domain.Interfaces
{
    public interface IShoppingCartService
    {
		void AddToCart(string username, Product product);
		ShoppingCart GetCart(string username);
		void EmptyCart(string username);
		void DeleteProduct(string username, Product product);
		
	}
}
