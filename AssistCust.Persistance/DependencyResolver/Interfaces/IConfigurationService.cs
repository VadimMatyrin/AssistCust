using Microsoft.Extensions.Configuration;

namespace AssistCust.Persistance.DependencyResolver.Interfaces
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}