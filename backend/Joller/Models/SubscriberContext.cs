using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Joller.Models
{
    public class SubscriberContext
    {
        private readonly IMongoDatabase _database = null;

        public SubscriberContext(IOptions<Settings> Settings)
        {
            var client = new MongoClient(Settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(Settings.Value.Database);
        }
        public SubscriberContext(string ConnectionUrl)
        {
            var client = new MongoClient(ConnectionUrl);
            if (client != null)
                _database = client.GetDatabase("Subscribers");
        }
        public IMongoCollection<Subscriber> Subscribers
        {
            get
            {
                return _database.GetCollection<Subscriber>("Subscriber");
            }
        }
    }
}