using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Contexts;
using Joller.Models;
using Joller.Repositories.Interfaces;
using MongoDB.Bson;

namespace Joller.Repositories
{
    public class AboutMeRepository : IAboutMeRepository
    {
        private readonly AboutMeContext _context;
        public AboutMeRepository(string ConnectionUrl)
        {
            this._context = new AboutMeContext(ConnectionUrl);

        }

        public async Task AddPost(AboutMe item)
        {
            try
            {
                await _context.AboutMe.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<IEnumerable<AboutMe>> GetAllPosts()
        {
            throw new System.NotImplementedException();
        }

        public async Task<AboutMe> GetFirstPost()
        {
            var items = await this._context.AboutMe.FindAsync<AboutMe>(new BsonDocument());
            await items.MoveNextAsync();

            return null;
        }

        public Task<AboutMe> GetPost(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemovePost(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePost(string id, Subscriber Subscriber)
        {
            throw new System.NotImplementedException();
        }
    }
}