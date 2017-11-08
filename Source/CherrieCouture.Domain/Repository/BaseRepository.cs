using MongoDB.Driver;
using MongoDB.Bson;

namespace CherrieCouture.Domain.Repository
{
	public class BaseRepository
	{
		private string _connectionString;
		private readonly MongoClient _client;
		protected IMongoDatabase database;

		public BaseRepository(string connectionString)
		{
			_connectionString = connectionString;
			_client = new MongoClient(connectionString);
			database = _client.GetDatabase("CherrieCouture");
		}
	}
}
