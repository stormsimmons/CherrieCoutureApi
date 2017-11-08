using CherrieCouture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherrieCouture.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CherrieCouture.Domain.Repository
{
	public class ProductRepository : BaseRepository, IProductRepository
	{
		public ProductRepository(string connectionString) : base(connectionString)
		{
		}

		public void Delete(Product product)
		{
			var collection = database.GetCollection<Product>("Products");
			var filter = Builders<Product>.Filter.Eq("Id", product.Id);
			collection.DeleteOne(filter);
		}

		public Product GetProduct(string objectId)
		{
			var collection = database.GetCollection<Product>("Products");
			var filter = Builders<Product>.Filter.Empty;
			var list = collection.Find(filter).ToList();
			var product = list.FirstOrDefault(x => x.Id.ToString() == objectId);
			return product;
		}

		public void Insert(Product product)
		{
			var collection = database.GetCollection<Product>("Products");
			collection.InsertOne(product);
		}

		public IList<Product> List()
		{
			var collection = database.GetCollection<Product>("Products");
			var filter = Builders<Product>.Filter.Empty;
			var list = collection.Find(filter).ToList();
			return list;
		}

		public void Update(Product product)
		{
			var collection = database.GetCollection<Product>("Products");
			var filter = Builders<Product>.Filter.Eq("Id", product.Id);
			collection.ReplaceOne(filter, product);
		}
	}
}
