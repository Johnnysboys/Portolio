using Joller.Models;

namespace Joller.Authentication
{
    public interface IJwtSigner
    {
        string GenerateToken(User user);

    }
}