using Nancy;
using System;
using Bubber.BusinessLogic.Services;

namespace Bubber.Modules
{
    public class NewsLetter : NancyModule
    {
        private DatabaseService db = new DatabaseService("newsletter");
        public NewsLetter() : base("/newsletter")
        {
            Get("/", args =>
                {
                    return "NO!";
                });

            Post("/{email}", args =>
            {
                return "HAHA!";
            });
        }

    }
}