using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Authentication.Domain.Entities;

namespace Authentication.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase(configuration["DatabaseName"]);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
