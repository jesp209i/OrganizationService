using MediatR;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using Rebus.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.OrganizationMember
{
    public class ChangeMemberPermissionRequest : IRequest<Guid>
    {
        public ChangeMemberPermissionRequest(string organizationId, string email, int permission, DateTime changeDate, string changedBy)
        {
            OrganizationId = organizationId;
            Email = email;
            Permission = permission;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public string OrganizationId { get; set; }
        public string Email { get; set; }
        public int Permission { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class ChangeMemberPermissionRequestHandler : IRequestHandler<ChangeMemberPermissionRequest, Guid>
    {
        private readonly IBus _bus;

        public ChangeMemberPermissionRequestHandler(IBus bus)
        {
            _bus = bus;
        }
        public async Task<Guid> Handle(ChangeMemberPermissionRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangeOrganizationMemberPermissionCommand(
                new Guid(request.OrganizationId),
                request.Email,
                request.Permission,
                request.ChangeDate,
                request.ChangedBy
                );

            await _bus.Send(command);

            return await Task.FromResult(Guid.Empty);
        }
    }
}
