using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

using Joller.Models;
using Joller.Repositories.Interfaces;

namespace Joller
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public Bootstrapper()
        {

        }
        public Bootstrapper(ISubscriberRepository subscriberRepository)
        {
            this._subscriberRepository = subscriberRepository;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_subscriberRepository);
        }
    }
}