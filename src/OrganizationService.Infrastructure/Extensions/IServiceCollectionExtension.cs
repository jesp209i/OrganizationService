using Microsoft.Extensions.DependencyInjection;
using OrganizationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationPersistenceAdapter,OrganizationPersistenceAdapter>();
            
            return services;
        }

        public static IServiceCollection AddReadOnlyInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IReadOnlyOrganizationPersistenceAdapter, ReadOnlyOrganizationPersistenceAdapter>();

            return services;
        }
    }
}
