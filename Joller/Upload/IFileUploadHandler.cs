using System.IO;
using System.Threading.Tasks;
using Joller.Models;

namespace Joller.Upload
{
    public interface IFileUploadHandler
    {
        Task<FileUploadResult> HandleUpload(string fileName, Stream stream);
    }
}