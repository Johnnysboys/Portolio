using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Contexts;
using Joller.Models;
using Joller.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

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
        public async Task<long> CountPosts()
        {
            return await this._context.AboutMe.CountAsync(new BsonDocument());
        }
        public async Task<IEnumerable<AboutMe>> GetAllPosts()
        {
            var sorting = Builders<AboutMe>.Sort.Descending("_id");
            var options = new FindOptions<AboutMe, AboutMe> { Sort = sorting };

            var Collection = await this._context.AboutMe.FindAsync<AboutMe>(new BsonDocument(), options);
            var AboutMes = new List<AboutMe>();
            while (await Collection.MoveNextAsync())
            {
                AboutMes.AddRange(Collection.Current);

            }
            return AboutMes;
        }

        public async Task<AboutMe> GetFirstPost()
        {
            var sorting = Builders<AboutMe>.Sort.Descending("_id");
            var options = new FindOptions<AboutMe, AboutMe> { Sort = sorting };

            var items = await this._context.AboutMe.FindAsync<AboutMe>(new BsonDocument(), options);

            while (await items.MoveNextAsync())
            {
                foreach (var item in items.Current)
                {
                    return item;
                }
            }

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