using Joller.Models;
using System;
namespace Joller
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public HomeModule(ISubscriberRepository subscriberRepository)
        {
            this._subscriberRepository = subscriberRepository;
            Console.WriteLine(_subscriberRepository);
            Get("/", async args =>
            {
                var all = await this._subscriberRepository.GetAllSubscribers();
                return Response.AsJson(all);
            });
            Post("/", args =>
            {
                var subscriber = new Subscriber
                {
                    FirstName = "Simon",
                    LastName = "Sinding",
                    Email = "sinding2000@gmail.com"
                };
                this._subscriberRepository.AddSubscriber(subscriber);

                return Response.AsJson(subscriber);
            });
        }
    }
}
