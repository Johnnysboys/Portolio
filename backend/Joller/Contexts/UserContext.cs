using Joller.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Joller.Contexts
{
    public class UserContext
    {
        private readonly IMongoDatabase _database = null;

        public UserContext(IOptions<Settings> Settings)
        {
            var client = new MongoClient(Settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(Settings.Value.Database);
        }
        public UserContext(string ConnectionUrl)
        {
            var client = new MongoClient(ConnectionUrl);
            if (client != null)
                _database = client.GetDatabase("Joller");
        }
        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }
    }
}