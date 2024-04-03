using firstapp.Models;
using MongoDB.Driver;

namespace firstapp.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Vote> Votes => _database.GetCollection<Vote>("Votes");
    }
}
