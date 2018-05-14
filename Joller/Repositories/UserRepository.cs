using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Contexts;
using Joller.Models;
using Joller.Repositories.Interfaces;
using MongoDB.Bson;

namespace Joller.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context = null;
        private readonly Settings _settings;

        public UserRepository(string ConnectionUrl)
        {
            this._context = new UserContext(ConnectionUrl);
        }
        public async Task<bool> AddUser(User item)
        {
            try
            {
                var Result = await _context.Users.CountAsync(new BsonDocument("Email", item.Email));
                Console.WriteLine(Result);
                if (Result > 0)
                    return false;
                await this._context.Users.InsertOneAsync(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var Collection = await this._context.Users.FindAsync<User>(new BsonDocument());
            var Users = new List<User>();
            while (await Collection.MoveNextAsync())
            {
                Users.AddRange(Collection.Current);

            }
            return Users;
        }

        public async Task<User> GetUser(string id)
        {
            var Filter = new BsonDocument("Email", id);
            var Result = await this._context.Users.FindAsync<User>(Filter);
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

        public Task<bool> RemoveAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUser(string id, User User)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserDocument(string id, User User)
        {
            throw new System.NotImplementedException();
        }
    }
}