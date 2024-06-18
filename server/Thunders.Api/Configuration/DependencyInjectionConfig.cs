using Thunders.Domain.Interfaces.IService;
using Thunders.Infra.Context;
using Thunders.Service;

namespace Thunders.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<ITaskService, TaskService>();

            services.AddHttpClient();
        }
    }
}
