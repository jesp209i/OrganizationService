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
    public class ChangeOrganizationVatNumberCommandHandler : IHandleMessages<ChangeOrganizationVatNumberCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<ChangeOrganizationVatNumberCommandHandler> _logger;

        public ChangeOrganizationVatNumberCommandHandler(IOrganizationWorkerService organizationService, ILogger<ChangeOrganizationVatNumberCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }

        public async Task Handle(ChangeOrganizationVatNumberCommand m)
        {

            var organization = new ChangeOrganizationVatNumberDto
            {
                Id = m.Id,
                VatNumber = m.VatNumber,                
                ChangeDate = m.ChangeDate,
                ChangedBy = m.ChangedBy
            };
            await _organizationService.ChangeOrganizationVatNumber(organization);
        }
    }
}
