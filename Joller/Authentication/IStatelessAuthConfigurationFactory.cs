using Nancy.Authentication.Stateless;

namespace Joller.Authentication
{
    public interface IStatelessAuthConfigurationFactory
    {
        StatelessAuthenticationConfiguration Create();
    }
}