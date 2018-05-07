using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joller.Models
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAllSubscribers();
        Task<Subscriber> GetSubscriber(string id);

        // add new Subscriber document
        Task AddSubscriber(Subscriber item);

        // remove a single document / Subscriber
        Task<bool> RemoveSubscriber(string id);

        // update just a single document / Subscriber
        Task<bool> UpdateSubscriber(string id, string body);

        // demo interface - full document update
        Task<bool> UpdateSubscriberDocument(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllSubscribers();
    }
}