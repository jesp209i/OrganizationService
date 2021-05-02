using Microsoft.Extensions.Logging;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Worker.Handlers.Organization
{
    public class ChangeOrganizationAddressCommandHandler : IHandleMessages<ChangeOrganizationAddressCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<ChangeOrganizationAddressCommandHandler> _logger;

        public ChangeOrganizationAddressCommandHandler(IOrganizationWorkerService organizationService, ILogger<ChangeOrganizationAddressCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }
        public async Task Handle(ChangeOrganizationAddressCommand m)
        {
            var organization = new ChangeOrganizationAddressDto
            {
                Id = m.Id,
                Street = m.Street,
                StreetExtended = m.StreetExtended,
                PostalCode = m.PostalCode,
                City = m.City,
                Country = m.Country,
                ChangeDate = m.ChangeDate,
                ChangedBy = m.ChangedBy
            };
            await _organizationService.ChangeOrganizationAddress(organization);
        }
    }
}
