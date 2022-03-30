using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCHOOL_PROJECT_SERVICE.DependencyInjection.ApplicationServiceInjection;
using SCHOOL_PROJECT_SERVICE.DependencyInjection.RepositoryInjection;
using SCHOOL_PROJECT_SERVICE.DependencyInjection.UnitOfWorkInjection;

namespace SCHOOL_PROJECT_SERVICE.DependencyInjection
{
    public static class ConfigureBindingsDependencyInjection
    {

        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsApplicationService.RegisterBindings(services, configuration);
            ConfigureBindingsRepository.RegisterBindings(services, configuration);
            ConfigureBindinsUnifOfWorks.RegisterBindings(services, configuration);
        }
    }
}