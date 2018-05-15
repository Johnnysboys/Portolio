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

        // Misleading name, but dont wanna rename it at this point
        // it's the posts endpoint now
        private async void InitPost()
        {
            var count = await this._repo.CountPosts();
            if (count == 0)
            {
                await this._repo.AddPost(new AboutMe { Text = "<div align=\"center\">My name is Simon Sinding<br>Im 25, IT Engineering student, and <b>awesome</b>.<br></div><br>" });
            }
        }
        public AboutMeModule(IAboutMeRepository repo) : base("/posts")
        {
            this._repo = repo;
            this.InitPost();
            Get("/", async args =>
            {
                var post = await this._repo.GetFirstPost();
                return Response.AsJson(post);
            });
            Get("/all", async args =>
            {
                var posts = await this._repo.GetAllPosts();
                return Response.AsJson(posts);
            });

            Post("/", async args =>
            {
                this.RequiresAuthentication();
                this.RequiresClaims(c => c.Value.Equals("admin"));

                var post = this.Bind<AboutMe>();

                if (String.IsNullOrWhiteSpace(post.Text))
                    return Response.AsJson(new { Status = "error", Message = "There has to be SOME text" });

                await this._repo.AddPost(post);
                return Response.AsJson(new { Status = "success", Message = "Done" });
            });
        }
    }
}