using Nancy;
using System.Collections.Generic;
namespace Joller.Upload
{
    public class FileUploadRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<string> Tags { get; set; }

        public HttpFile File { get; set; }
    }
}