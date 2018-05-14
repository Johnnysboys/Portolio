using Nancy;
using System;
using System.IO;
using System.Threading.Tasks;
using Joller.Models;
using System.Collections.Generic;

namespace Joller.Upload
{
    public class LocalFileServer : ILocalFileServer
    {
        private readonly string path;
        private readonly IRootPathProvider rootPathProvider;

        public LocalFileServer(IRootPathProvider rootPathProvider)
        {
            this.path = "Content/Images";
            this.rootPathProvider = rootPathProvider;
        }

        public async Task<List<string>> ListFiles()
        {
            var files = Directory.GetFiles(this.rootPathProvider.GetRootPath() + this.path);
            List<string> sanitizedFileNames = new List<string>();

            foreach (var filepath in files)
            {
                var splitPath = filepath.Split("/");
                sanitizedFileNames.Add(splitPath[splitPath.Length - 1]);
            }

            return sanitizedFileNames;
        }
    }
}