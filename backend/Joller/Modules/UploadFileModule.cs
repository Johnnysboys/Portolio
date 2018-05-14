using Joller.Upload;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Joller.Modules
{
    public class UploadFileModule : NancyModule
    {
        private readonly IFileUploadHandler fileUploadHandler;
        private readonly ILocalFileServer fileServer;

        public UploadFileModule(IFileUploadHandler fileUploadHandler, ILocalFileServer LocalFileServer)
            : base("/file")
        {

            // It requires you to be an admin to upload

            this.fileUploadHandler = fileUploadHandler;
            this.fileServer = LocalFileServer;
            Get("/", async args =>
            {
                var list = await this.fileServer.ListFiles();
                var res = new
                {
                    Status = "success",
                    Data = list
                };
                return Response.AsJson(res);
            });
            Post("/upload", async parameters =>
            {
                this.RequiresAuthentication();
                this.RequiresClaims(c => c.Value.Equals("admin"));
                var request = this.Bind<FileUploadRequest>();

                var uploadResult = await fileUploadHandler.HandleUpload(request.File.Name, request.File.Value);

                var response = new FileUploadResponse() { Identifier = uploadResult.Identifier };

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(response);
            });
        }
    }
}