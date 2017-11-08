using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCouture.Domain.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Repository
{
	public class OrderRepository : BaseRepository, IOrderRepository
	{
		public OrderRepository(string connectionString) : base(connectionString)
		{
		}

		public void Delete(Order order)
		{
			var collection = database.GetCollection<Order>("Orders");
			var filter = Builders<Order>.Filter.Eq("Id", order.Id);
			collection.DeleteOne(filter);
		}

		public Order GetOrder(string orderId)
		{
			var collection = database.GetCollection<Order>("Order");
			var filter = Builders<Order>.Filter.Empty;
			var list = collection.Find(filter).ToList();
			return list.FirstOrDefault(x => x.Id.ToString() == orderId);
		}

		public void Insert(Order order)
		{
			var collection = database.GetCollection<Order>("Orders");
			collection.InsertOne(order);
		}

		public IList<Order> List()
		{
			var collection = database.GetCollection<Order>("Orders");
			var filter = Builders<Order>.Filter.Empty;
			return collection.Find(filter).ToList();
		}

		public void Update(Order order)
		{
			var collection = database.GetCollection<Order>("Orders");
			var filter = Builders<Order>.Filter.Eq("Id", order.Id);
			collection.ReplaceOne(filter, order);
		}
	}
}
