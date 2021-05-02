using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganizationService.Shared.Messages.Commands.Organization;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using Rebus.Config;
using Rebus.Retry.Simple;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;


namespace OrganizationService.Worker.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRebusServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AutoRegisterHandlersFromAssemblyOf<Program>();

            var serviceBusConnectionString = configuration[Constants.EnvironmentVariables.ServiceBusConnectionStringEnvironmentVariableName];
            
            services.AddRebus(configure 
                => configure.Transport(t 
                => t.UseAzureServiceBus(serviceBusConnectionString, Constants.ServiceBus.InputQueue)
                .UseLegacyNaming())
                .Options(
                    o =>
                    {
                        o.SimpleRetryStrategy(Constants.ServiceBus.ErrorQueue, 5);
                    })
                .Routing(r => r.TypeBased()
                .Map(typeof(CreateOrganizationCommand), Constants.ServiceBus.InputQueue)
                .Map(typeof(ChangeOrganizationAddressCommand), Constants.ServiceBus.InputQueue)
                .Map(typeof(ChangeOrganizationVatNumberCommand), Constants.ServiceBus.InputQueue)
                .Map(typeof(ChangeOrganizationWebsiteCommand), Constants.ServiceBus.InputQueue)
                .Map(typeof(AddOrganizationMemberCommand), Constants.ServiceBus.InputQueue)
                .Map(typeof(ChangeOrganizationMemberPermissionCommand), Constants.ServiceBus.InputQueue)
                )
                
                );
            return services;
        }
    }
}
