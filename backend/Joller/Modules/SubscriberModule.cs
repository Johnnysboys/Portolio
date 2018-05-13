using Joller.Models;
using Joller.Repositories.Interfaces;
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

            // Read All
            Get("/subscribers", async parameters =>
            {
                return await Response.AsJson(this._subscriberRepository.GetAllSubscribers());
            });

            // Read A Specific
            Get("/subscribers/{email}", async parameters =>
            {
                // Create subscriber from the recived data
                Subscriber Subscriber = await this._subscriberRepository.GetSubscriber(parameters.email);
                if (Subscriber == null)
                    return Response.AsJson(new { Error = "No subscriber found with id " + parameters.email });

                return Response.AsJson(Subscriber);
            });

            // Create
            Post("/subscribers", parameters =>
            {
                // Create subscriber from the recived data 
                var Subscriber = this.Bind<Subscriber>();
                Subscriber.Subscribed = true;
                this._subscriberRepository.AddSubscriber(Subscriber);
                return Response.AsJson(Subscriber);
            });

            // Update
            Patch("/subscribers/{email}/unsubscribe", async parameters =>
            {
                // Create subscriber from the recived data
                bool Unsubscribed = await this._subscriberRepository.Unsubscribe(parameters.email);

                if (!Unsubscribed)
                    return Response.AsJson("Failed");
                return Response.AsJson("Success");
            });

            // Delete
            Delete("/subscribers/{email}", async parameters =>
            {
                // Create subscriber from the recived data
                bool Deleted = await this._subscriberRepository.RemoveSubscriber(parameters.email);

                if (!Deleted)
                    return Response.AsJson("Failed");
                return Response.AsJson("Success");
            });
        }
    }
}
