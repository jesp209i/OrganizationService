using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrganizationService.Persistence.Interfaces;
using OrganizationService.Persistence.Repositories;

namespace OrganizationService.Persistence.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
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

        public static IServiceCollection AddReadOnlyPersistence(this IServiceCollection services, IConfiguration configuration)
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
