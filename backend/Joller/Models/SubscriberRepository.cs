using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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
            try
            {
                return await (await _context.Subscribers
                        .FindAsync(_ => true)).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<Subscriber> GetSubscriber(string id)
        {
            throw new System.NotImplementedException();
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