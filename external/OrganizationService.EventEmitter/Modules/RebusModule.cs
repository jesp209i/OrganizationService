using Autofac;
using System;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using OrganizationService.Shared.Messages.Commands.Organization;

namespace OrganizationService.EventEmitter.Modules
{
    public class RebusModule : Module
    {
        private string InputQueue => "Servicebus_Organization_input".ToLower();


        protected override void Load(ContainerBuilder builder)
        {
            var servicebusConnectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTION_STRING");

            builder.RegisterRebus(rc =>
                rc.Logging(l => l.ColoredConsole())
                .Transport(t => t.UseAzureServiceBusAsOneWayClient(servicebusConnectionString)
                    .UseLegacyNaming())
                .Routing(r => r.TypeBased()
                    .Map(typeof(CreateOrganizationCommand), InputQueue)
                    .Map(typeof(ChangeOrganizationAddressCommand), InputQueue)
                    .Map(typeof(ChangeOrganizationVatNumberCommand), InputQueue)
                    .Map(typeof(ChangeOrganizationWebsiteCommand), InputQueue))
            );
        }
    }
}
