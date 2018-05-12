using Joller.Models;
using Nancy.ModelBinding;
using System;
namespace Joller.Modules
{
    using Nancy;

    public class SubscriberModule : NancyModule
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public SubscriberModule(ISubscriberRepository subscriberRepository)
        {
            this._subscriberRepository = subscriberRepository;
            Get("/subscribers", async parameters =>
            {
                return await Response.AsJson(this._subscriberRepository.GetAllSubscribers());
            });
            Post("/subscribers", parameters =>
            {
                // Create subscriber from the recived data 
                var Subscriber = this.Bind<Subscriber>();
                Subscriber.Subscribed = true;
                this._subscriberRepository.AddSubscriber(Subscriber);
                return Response.AsJson(Subscriber);
            });
            Patch("/subscribers/{id:int}", parameters =>
            {
                // Create subscriber from the recived data 

                this._subscriberRepository.GetSubscriber(parameters.id);

                return Response.AsJson("Subscriber");
            });
        }
    }
}
