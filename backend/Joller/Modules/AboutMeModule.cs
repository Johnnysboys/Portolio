using System;
using Joller.Models;
using Joller.Repositories;
using Joller.Repositories.Interfaces;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Joller.Modules
{
    public class AboutMeModule : NancyModule
    {
        private readonly IAboutMeRepository _repo;
        public AboutMeModule(IAboutMeRepository repo) : base("/aboutme")
        {
            this._repo = repo;
            Get("/", args =>
            {
                return Response.AsJson(new { Ret = " Er Træt" });
            });
            Post("/", args =>
            {
                this.RequiresAuthentication();
                this.RequiresClaims(c => c.Value.Equals("admin"));

                var post = this.Bind<AboutMe>();

                if (String.IsNullOrWhiteSpace(post.Text))
                    return Response.AsJson(new { Status = "error", Message = "There has to be SOME text" });
                return Response.AsJson(new { Status = "success", Message = "Done" });
            });
        }
    }
}