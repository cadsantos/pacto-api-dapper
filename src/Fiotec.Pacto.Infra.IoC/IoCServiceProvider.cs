using Fiotec.Pacto.Infra.IoC.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiotec.Pacto.Infra.IoC
{
    public static class IoCServiceProvider
    {
        public static void ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            ServiceInfrastrutureExtensions.AddServiceInfrastruture(services, configuration);
            ServiceApplicationExtensions.AddServiceApplication(services);
        }
    }
}
