using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Infrastructure.Repositories;
using OrganizationService.Infrastructure.Mapper;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;

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

            services.AddTransient<IMapper<OrganizationMember, OrganizationMemberEntity>, OrganizationMemberEntityMapper>();
            services.AddTransient<IMapper<Organization, OrganizationEntity>, OrganizationEntityMapper>();
            services.AddTransient<IMapper<OrganizationMemberEntity, OrganizationMember>, OrganizationMemberDomainMapper>();
            services.AddTransient<IMapper<OrganizationEntity, Organization>, OrganizationDomainMapper>();

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

            services.AddTransient<IMapper<OrganizationMemberEntity, OrganizationMember>, OrganizationMemberDomainMapper>();
            services.AddTransient<IMapper<OrganizationEntity, Organization>, OrganizationDomainMapper>();

            return services;
        }
    }
}
