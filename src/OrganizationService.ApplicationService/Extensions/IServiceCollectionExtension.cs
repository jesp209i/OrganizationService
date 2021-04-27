using Microsoft.Extensions.DependencyInjection;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Services;

namespace OrganizationService.ApplicationService.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationWorkerService, OrganizationWorkerService>();

            return services;
        }

        public static IServiceCollection AddReadOnlyApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationReadOnlyService, OrganizationReadOnlyService>();

            return services;
        }
    }
}
