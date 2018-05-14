using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joller.Upload
{
    public interface ILocalFileServer
    {
        Task<List<string>> ListFiles();
    }
}