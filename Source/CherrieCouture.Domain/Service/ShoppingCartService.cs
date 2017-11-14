using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CherrieCouture.Domain.Models;
using System.Linq;

namespace CherrieCouture.Domain.Service
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;
		public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
		{
			_shoppingCartRepository = shoppingCartRepository;
		}
		public void AddToCart(string username, Product product)
		{
			var cart = _shoppingCartRepository.GetShoppingCart(username);
			cart.ProductList.Add(product);
			_shoppingCartRepository.Update(username, cart);
		}

		public ShoppingCart GetCart(string username)
		{
			return _shoppingCartRepository.GetShoppingCart(username);
		}

		public void EmptyCart(string username)
		{
			var cart = _shoppingCartRepository.GetShoppingCart(username);
			cart.ProductList = new List<Product>();

			_shoppingCartRepository.Update(username, cart);
		}

		public void DeleteProduct(string username,Product product)
		{
			var cart = _shoppingCartRepository.GetShoppingCart(username);
			var producTtoDelete = cart.ProductList.FirstOrDefault(x => x.Id == product.Id);
			cart.ProductList.Remove(producTtoDelete);
			_shoppingCartRepository.Update(username, cart);
		}
	}
}
