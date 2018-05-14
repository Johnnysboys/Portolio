using Joller.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Joller.Contexts
{
    public class AboutMeContext
    {
        private readonly IMongoDatabase _database = null;

        public AboutMeContext(IOptions<Settings> Settings)
        {
            var client = new MongoClient(Settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(Settings.Value.Database);
        }
        public AboutMeContext(string ConnectionUrl)
        {
            var client = new MongoClient(ConnectionUrl);
            if (client != null)
                _database = client.GetDatabase("Joller");
        }
        public IMongoCollection<AboutMe> AboutMe
        {
            get
            {
                return _database.GetCollection<AboutMe>("AboutMePosts");
            }
        }
    }
}