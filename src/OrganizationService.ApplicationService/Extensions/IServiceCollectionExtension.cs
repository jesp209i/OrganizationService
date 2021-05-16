using Microsoft.Extensions.DependencyInjection;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Mapper;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;

namespace OrganizationService.ApplicationService.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationWorkerService, OrganizationWorkerService>();
            services.AddTransient<IMapper<OrganizationDto, Organization>, OrganizationDomainMapper>();

            return services;
        }

        public static IServiceCollection AddReadOnlyApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationReadOnlyService, OrganizationReadOnlyService>();
            services.AddTransient<IMapper<Organization, OrganizationDto>, OrganizationDtoMapper>();
            services.AddTransient<IMapper<OrganizationMember, OrganizationMemberDto>, OrganizationMemberDtoMapper>();

            return services;
        }
    }
}
