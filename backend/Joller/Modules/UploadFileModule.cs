using Joller.Upload;
using Nancy;
using Nancy.ModelBinding;

namespace Joller.Modules
{
    public class UploadFileModule : NancyModule
    {
        private readonly IFileUploadHandler fileUploadHandler;

        public UploadFileModule(IFileUploadHandler fileUploadHandler)
            : base("/file")
        {
            this.fileUploadHandler = fileUploadHandler;

            Post("/upload", async parameters =>
            {
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