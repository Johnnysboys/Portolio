using Nancy;
using System;
using System.IO;
using System.Threading.Tasks;
using Joller.Models;

namespace Joller.Upload
{
    public class LocalStorageHandler : IFileUploadHandler
    {
        private readonly string path;
        private readonly IRootPathProvider rootPathProvider;

        public LocalStorageHandler(IRootPathProvider rootPathProvider)
        {
            this.path = "uploads";
            this.rootPathProvider = rootPathProvider;
        }

        public async Task<FileUploadResult> HandleUpload(string fileName, System.IO.Stream stream)
        {
            string uuid = GetFileName();
            string targetFile = GetTargetFile(uuid);

            using (FileStream destinationStream = File.Create(targetFile))
            {
                await stream.CopyToAsync(destinationStream);
            }

            return new FileUploadResult()
            {
                Identifier = uuid
            };
        }

        private string GetTargetFile(string fileName)
        {
            return Path.Combine(GetUploadDirectory(), fileName);
        }

        private string GetFileName()
        {
            return Guid.NewGuid().ToString();
        }

        private string GetUploadDirectory()
        {
            var uploadDirectory = Path.Combine(rootPathProvider.GetRootPath(), path);
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            return uploadDirectory;
        }
    }
}