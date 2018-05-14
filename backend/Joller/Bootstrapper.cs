using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Joller.Authentication;
using Joller.Repositories;
using Joller.Repositories.Interfaces;
using Nancy.Authentication.Stateless;

namespace Joller
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {


        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAboutMeRepository _aboutMeRepository;
        public Bootstrapper()
        {
        }
        public Bootstrapper(string mongodbUrl)
        {

            this._subscriberRepository = new SubscriberRepository(mongodbUrl);
            this._userRepository = new UserRepository(mongodbUrl);
            this._aboutMeRepository = new AboutMeRepository(mongodbUrl);
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var StatelessAuthConfigurationFactory = container.Resolve<IStatelessAuthConfigurationFactory>();
            var configuration = StatelessAuthConfigurationFactory.Create();

            StatelessAuthentication.Enable(pipelines, configuration);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_subscriberRepository);
            container.Register(_userRepository);
            container.Register(_aboutMeRepository);
        }
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type, Authorization");

            });
        }
    }
}