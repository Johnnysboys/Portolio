using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

namespace Joller.Models
{
    public class SubscriberRepository : ISubscriberRepository
    {

        private readonly SubscriberContext _context = null;

        public SubscriberRepository(IOptions<Settings> Settings)
        {
            this._context = new SubscriberContext(Settings);
        }
        public SubscriberRepository(string ConnectionUrl)
        {
            this._context = new SubscriberContext(ConnectionUrl);
        }

        // public async Task<List<String>> FindAll()
        // {
        //     var subs = await this._context.Subscribers.FindAsync<Subscriber>(new BsonDocument());
        //     var Cat = new List<String>();



        //     while(await subs.MoveNextAsync()) {
        //         Cat.Add(subs.Current);
        //     }

        //     System.Console.Write(subs.ToString());

        // }
        public async Task AddSubscriber(Subscriber item)
        {
            try
            {
                await _context.Subscribers.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Subscriber>> GetAllSubscribers()
        {
            var Collection = await this._context.Subscribers.FindAsync<Subscriber>(new BsonDocument());
            var Subscribers = new List<Subscriber>();
            while (await Collection.MoveNextAsync())
            {
                Subscribers.AddRange(Collection.Current);

            }
            return Subscribers;
        }

        public async Task GetSubscriber(int id)
        {
            var Filter = new BsonDocument("SubscriberId", id);
            var Result = await this._context.Subscribers.FindAsync<Subscriber>(Filter);
            while (await Result.MoveNextAsync())
            {
                foreach (var item in Result.Current)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
            // return 


        }

        public Task<bool> RemoveAllSubscribers()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveSubscriber(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateSubscriber(string id, string body)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateSubscriberDocument(string id, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}