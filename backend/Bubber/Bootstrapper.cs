using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.TinyIoc;
using Bubber.BusinessLogic.Services;
using Bubber.BusinessLogic.Services.Interfaces;
using System;
using Nancy.Bootstrapper;
using Nancy.Authentication.Forms;

namespace Bubber
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppSettings appSettings;
        private readonly IServiceProvider serviceProvider;
        public Bootstrapper()
        {
        }

        public Bootstrapper(IAppSettings appSet, IServiceProvider serviceProv)
        {
            appSettings = appSet;
            serviceProvider = serviceProv;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(appSettings);
            container.Register(serviceProvider.GetService<ILoggerFactory>());

            container.Register<IVersionService, VersionService>();
        }


        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/ login",
                    UserMapper = requestContainer.Resolve<IUserMapper>(),
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

    }
}
