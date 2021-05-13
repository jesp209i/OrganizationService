using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Infrastructure.Repositories;

namespace OrganizationService.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrganizationDbContext>(options =>
            {
                var conStr = configuration[Constants.EnvironmentVariables.DatabaseConnectionString];
                options.UseSqlServer(conStr,
                    b => b.MigrationsAssembly(typeof(OrganizationDbContext).FullName));
            });

            services.AddScoped<IReadWriteOrganizationRepository, ReadWriteOrganizationRepository>();
            //services.AddScoped<IReadOnlyOrganizationMemberRepository, ReadOnlyOrganizationMemberRepository>();

            return services;
        }

        public static IServiceCollection AddReadOnlyInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrganizationDbContext>(options => 
            {
                var conStr = configuration[Constants.EnvironmentVariables.DatabaseConnectionString];
                options.UseSqlServer(conStr,
                    b => b.MigrationsAssembly(typeof(OrganizationDbContext).Assembly.FullName));
            });

            services.AddScoped<IReadOnlyOrganizationRepository, ReadOnlyOrganizationRepository>();
            services.AddScoped<IReadOnlyOrganizationMemberRepository, ReadOnlyOrganizationMemberRepository>();

            return services;
        }
    }
}
