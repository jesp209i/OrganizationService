using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter
{
    internal class OrganizationServiceEventEmitter
    {
        private readonly IBus _bus;

        public OrganizationServiceEventEmitter(IBus bus)
        {
            _bus = bus;
        }
        internal async Task Run(string[] args)
        {
            Console.WriteLine("Sending CreateOrganizationCommand");
            var hest = new CreateOrganizationCommand(Guid.NewGuid(), "test", "street", "streetextended", "postalcode","city", "country", "vatnumber", "website", DateTime.UtcNow, "Jesper");
            
            await _bus.Send(hest);
        }


    }
}