using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Models;

namespace Joller.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string id);

        // add new User document
        Task<bool> AddUser(User item);

        // remove a single document / User
        Task<bool> RemoveUser(string id);

        // update just a single document / User
        Task<bool> UpdateUser(string id, User User);

        // demo interface - full document update
        Task<bool> UpdateUserDocument(string id, User User);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllUsers();
    }
}