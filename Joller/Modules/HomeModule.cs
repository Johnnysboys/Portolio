using Joller.Models;
using System;
using Nancy;
using Nancy.Security;
using Nancy.Authentication.Stateless;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Net;
using System.Text;

namespace Joller
{

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.RequiresAuthentication();
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
