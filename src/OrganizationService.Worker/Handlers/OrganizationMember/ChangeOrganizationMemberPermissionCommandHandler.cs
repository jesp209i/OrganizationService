using Microsoft.Extensions.Logging;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.Enum;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using Rebus.Handlers;
using System.Threading.Tasks;

namespace OrganizationService.Worker.Handlers.OrganizationMember
{
    public class ChangeOrganizationMemberPermissionCommandHandler : IHandleMessages<ChangeOrganizationMemberPermissionCommand>
    {
        private readonly IOrganizationWorkerService _organizationService;
        private readonly ILogger<ChangeOrganizationMemberPermissionCommandHandler> _logger;

        public ChangeOrganizationMemberPermissionCommandHandler(IOrganizationWorkerService organizationService, ILogger<ChangeOrganizationMemberPermissionCommandHandler> logger)
        {
            _organizationService = organizationService;
            _logger = logger;
        }

        public async Task Handle(ChangeOrganizationMemberPermissionCommand message)
        {
            _logger.Log(LogLevel.Information, "ChangeOrganizationMemberPermissionCommandHandler invoked");
            var changePermission = new ChangeOrganizationMemberPermissionDto { 
                OrganizationId = message.OrganizationId,
                Email = message.MemberEmail,
                Permission = (Permission) message.Permission,
                ChangeDate = message.ChangeDate,
                ChangedBy = message.ChangedBy
            };
                
            await _organizationService.ChangeOrganizationMemberPermission(changePermission);
        }
    }
}
