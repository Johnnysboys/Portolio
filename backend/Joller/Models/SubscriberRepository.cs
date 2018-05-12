using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

using Joller.Exceptions;

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
        public async Task AddSubscriber(Subscriber item)
        {
            try
            {
                var Result = await _context.Subscribers.CountAsync(new BsonDocument("Email", item.Email));
                Console.WriteLine(Result);
                if (Result > 0)
                    throw new EmailAlreadyExistException(item.Email);
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
        public async Task<Subscriber> GetSubscriber(string id)
        {
            var Filter = new BsonDocument("Email", id);
            var Result = await this._context.Subscribers.FindAsync<Subscriber>(Filter);
            while (await Result.MoveNextAsync())
            {
                foreach (var item in Result.Current)
                {
                    return item;
                }
                return null;
            }
            return null;
        }

        public Task<bool> RemoveAllSubscribers()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> RemoveSubscriber(string email)
        {
            var Filter = new BsonDocument("Email", email);
            var Result = await this._context.Subscribers.DeleteOneAsync(Filter);

            if (!Result.IsAcknowledged)
                return Result.IsAcknowledged;

            return Result.DeletedCount > 0;
        }

        public async Task<bool> Unsubscribe(string id)
        {
            Subscriber Subscriber = await this.GetSubscriber(id);
            if (Subscriber == null)
                return false;
            Subscriber.Subscribed = false;

            return await this.UpdateSubscriber(id, Subscriber);
        }

        public async Task<bool> UpdateSubscriber(string id, Subscriber Subscriber)
        {
            var Filter = new BsonDocument("Email", id);
            var Update = new BsonDocument("$set", Subscriber.ToBsonDocument());
            var Result = await this._context.Subscribers.UpdateOneAsync(Filter, Update);


            return Result.IsAcknowledged;
        }
        public Task<bool> UpdateSubscriberDocument(string id, Subscriber Subscriber)
        {
            throw new NotImplementedException();
        }
    }
}