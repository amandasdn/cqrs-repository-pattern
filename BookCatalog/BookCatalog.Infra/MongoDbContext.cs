using BookCatalog.Domain.Entities;
using MongoDB.Driver;

namespace BookCatalog.Infra
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<BookEntity> Books => _database.GetCollection<BookEntity>("Books");
    }
}
