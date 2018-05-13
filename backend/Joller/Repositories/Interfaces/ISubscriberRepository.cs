using System.Collections.Generic;
using System.Threading.Tasks;
using Joller.Models;

namespace Joller.Repositories.Interfaces
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
        Task<bool> UpdateSubscriber(string id, Subscriber Subscriber);

        // demo interface - full document update
        Task<bool> UpdateSubscriberDocument(string id, Subscriber Subscriber);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllSubscribers();

        Task<bool> Unsubscribe(string id);
    }
}