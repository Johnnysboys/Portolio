using Joller.Models;
using System;
namespace Joller
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args =>
            {
                var data = new
                {
                    name = "Joller API",
                    version = 0.1,
                    author = "simon@coworkingplus.dk"
                };
                return Response.AsJson(data);
            });
        }
    }
}
