using Autofac;
using OrganizationService.EventEmitter.Modules;
using System;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var container = ConfigureContainer();
            var application = container.Resolve<OrganizationServiceEventEmitter>();
            while (true)
            {
                await application.Run(args);
            }

        }
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RebusModule>();
            builder.RegisterModule<MediatRModule>();
            builder.RegisterType<OrganizationServiceEventEmitter>().AsSelf();

            return builder.Build();
        }
    }
}
