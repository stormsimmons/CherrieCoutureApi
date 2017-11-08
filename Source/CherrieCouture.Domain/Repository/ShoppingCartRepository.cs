using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CherrieCouture.Domain.Models;
using MongoDB.Driver;
using System.Linq;

namespace CherrieCouture.Domain.Repository
{
	public class ShoppingCartRepository : BaseRepository, IShoppingCartRepository
	{
		public ShoppingCartRepository(string connectionString) : base(connectionString)
		{
		}

		public void Delete(string username)
		{
			var collection = database.GetCollection<ShoppingCart>("Users");
			var filter = Builders<ShoppingCart>.Filter.Eq("UserName",username);
			collection.DeleteOne(filter);
		}

		public ShoppingCart GetShoppingCart(string username)
		{
			var collection = database.GetCollection<ShoppingCart>("ShoppingCart");
			var filter = Builders<ShoppingCart>.Filter.Empty;
			var list = collection.Find(filter).ToList();
			return list.FirstOrDefault(x => x.UserName == username);
		}

		public void Insert(ShoppingCart shoppingCart)
		{
			var collection = database.GetCollection<ShoppingCart>("ShoppingCart");
			collection.InsertOne(shoppingCart);
		}

		public IList<ShoppingCart> List()
		{
			var collection = database.GetCollection<ShoppingCart>("ShoppingCarts");
			var filter = Builders<ShoppingCart>.Filter.Empty;
			return collection.Find(filter).ToList();
		}

		public void Update(string username, ShoppingCart shoppingCart)
		{
			var collection = database.GetCollection<ShoppingCart>("ShoppingCart");
			var filter = Builders<ShoppingCart>.Filter.Eq("UserName" , username);
			collection.ReplaceOne(filter, shoppingCart);
		}
	}
}
