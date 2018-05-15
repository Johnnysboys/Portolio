using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Models;

namespace Joller.Repositories.Interfaces
{
    public interface IAboutMeRepository
    {
        Task<AboutMe> GetFirstPost();
        Task<long> CountPosts();
        Task<IEnumerable<AboutMe>> GetAllPosts();
        Task<AboutMe> GetPost(string id);

        // add new Subscriber document
        Task AddPost(AboutMe item);

        // remove a single document / Subscriber
        Task<bool> RemovePost(string id);

        // update just a single document / Subscriber
        Task<bool> UpdatePost(string id, Subscriber Subscriber);
    }
}