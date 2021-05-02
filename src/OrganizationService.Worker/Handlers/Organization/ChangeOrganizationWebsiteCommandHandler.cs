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
    public class ChangeOrganizationWebsiteCommandHandler : IHandleMessages<ChangeOrganizationWebsiteCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<ChangeOrganizationWebsiteCommandHandler> _logger;

        public ChangeOrganizationWebsiteCommandHandler(IOrganizationWorkerService organizationService, ILogger<ChangeOrganizationWebsiteCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }

        public async Task Handle(ChangeOrganizationWebsiteCommand message)
        {
            var changeModel = new ChangeOrganizationWebsiteDto
            {
                Id = message.Id,
                Website = message.Website,
                ChangeDate = message.ChangeDate,
                ChangedBy = message.ChangedBy
            };
            await _organizationService.ChangeOrganizationWebsite(changeModel);
        }
    }
}
