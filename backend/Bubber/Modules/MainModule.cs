using Nancy;
using System;
using Bubber.BusinessLogic.Services.Interfaces;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Bubber.BusinessLogic.Services;

namespace Bubber.Modules
{
    public class MainModule : NancyModule
    {
        private readonly IVersionService versionService;

        public MainModule(IVersionService versionServiceSvc)
        {
            versionService = versionServiceSvc;



            Get("/", args =>
            {
                var model = new
                {
                    app = versionService.GetApplicationName(),
                    version = versionService.GetApplicationVersion(),
                    time = DateTime.Now
                };

                return Response.AsJson(model);
            });


            Post("/login", args =>
            {
                var user = UserProvider.ValidateUser((string)this.Request.Form.Username, (string)this.Request.Form.Password);

                if (user == null)
                {
                    var error = new Response();
                    error.StatusCode = HttpStatusCode.UnprocessableEntity;
                    error.ReasonPhrase = "Invalid user name / password.";
                    return error;
                }

                return this.LoginAndRedirect(user.ID);
            });

            Get("/logout", args =>
            {
                return this.LogoutAndRedirect("~/");
            });

            Get("/secure", args =>
            {
                this.RequiresAuthentication();

                var model = new
                {
                    loggedInAs = Context.CurrentUser.Identity.Name
                };

                return Response.AsJson(model);
            });
        }
    }
}
