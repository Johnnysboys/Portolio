using Nancy;
using System;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Bubber.Modules
{
    public class Page : NancyModule
    {
        private static string endpoint = "/about";
        public Page() : base(endpoint)
        {
            Get("/", args =>
                {
                    return Response.AsJson("Hey Fucker");
                });
            Post("/", args =>
               {
                   return Response.AsJson(CommonAnswers.NotSupported("POST"));
               });
        }
    }
}