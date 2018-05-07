using Nancy;
using System;

namespace Bubber.Modules
{
    public class UploadImage : NancyModule
    {
        private static string endpoint = "/upload";
        public UploadImage() : base(endpoint)
        {
            Get("/", args =>
            {
                return CommonAnswers.NotSupported("Get");
            });

            Post("/", args =>
            {
                return CommonAnswers.NotYetSupported("Post");
            });
            Put("/", args =>
            {
                return CommonAnswers.WrongUse("You need to provide an id");
            });
            Put("/{id}", args =>
            {
                return CommonAnswers.NotYetSupported("Put");
            });
            Delete("/", args =>
            {
                return CommonAnswers.NotYetSupported("Delete");
            });
            Patch("/", args =>
            {
                return CommonAnswers.NotSupported("Patch");
            });

        }
    }
}