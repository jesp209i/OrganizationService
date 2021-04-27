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
    public class CreateOrganizationCommandHandler : IHandleMessages<CreateOrganizationCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<CreateOrganizationCommandHandler> _logger;

        public CreateOrganizationCommandHandler(IOrganizationWorkerService organizationService, ILogger<CreateOrganizationCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }
        public async Task Handle(CreateOrganizationCommand m)
        {
            _logger.LogInformation("CreateOrganizationCommandHandler started");
            var organization = new OrganizationDto
            {
                Id = m.Id,
                Name = m.Name,
                Street = m.Street,
                StreetExtended = m.StreetExtended,
                PostalCode = m.PostalCode,
                City = m.City,
                Country = m.Country,
                VatNumber = m.VatNumber,
                Website = m.Website,
                ChangeDate = m.ChangeDate,
                ChangedBy = $"Servicebus: {m.ChangedBy}"
            };
            await _organizationService.AddOrganization(organization);
        }
    }
}
