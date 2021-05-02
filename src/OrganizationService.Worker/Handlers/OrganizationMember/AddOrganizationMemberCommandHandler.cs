using Microsoft.Extensions.Logging;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.Enum;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using OrganizationService.Worker.Handlers.Organization;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Worker.Handlers.OrganizationMember
{
    public class AddOrganizationMemberCommandHandler : IHandleMessages<AddOrganizationMemberCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<AddOrganizationMemberCommandHandler> _logger;

        public AddOrganizationMemberCommandHandler(IOrganizationWorkerService organizationService, ILogger<AddOrganizationMemberCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }

        public async Task Handle(AddOrganizationMemberCommand message)
        {
            var addMember = new OrganizationMemberDto
            {
                OrganizationId = message.OrganizationId,
                UserName = message.MemberName,
                Email = message.MemberEmail,
                Permission = (Permission)message.Permission,
                ChangeDate = message.ChangeDate,
                ChangedBy = message.ChangedBy
            };
            await _organizationService.AddOrganizationMember(addMember);
        }
    }

}
