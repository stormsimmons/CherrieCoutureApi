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
	public class UserRepository : BaseRepository, IUserRepository
	{
		public UserRepository(string connectionString) : base(connectionString)
		{
		}

		public void Delete(User user)
		{
			var collection = database.GetCollection<User>("Users");
			var filter = Builders<User>.Filter.Eq("UserName", user.UserName);
			collection.DeleteOne(filter);
		}

		public User GetUser(string userName)
		{

			var collection = database.GetCollection<User>("Users");
			var filter = Builders<User>.Filter.Empty;
			var list =  collection.Find(filter).ToList();
			return list.FirstOrDefault(x => x.UserName == userName);

		}

		public void Insert(User user)
		{
			
			var collection = database.GetCollection<User>("Users");
			collection.InsertOne(user);
		}

		public IList<User> List()
		{

			var collection = database.GetCollection<User>("Users");
			var filter = Builders<User>.Filter.Empty;
			return collection.Find(filter).ToList();
		}

		public void Update(User user)
		{
			var collection = database.GetCollection<User>("Users");
			var filter = Builders<User>.Filter.Eq("UserName", user.UserName);
			collection.ReplaceOne(filter, user);
		}
	}
}
