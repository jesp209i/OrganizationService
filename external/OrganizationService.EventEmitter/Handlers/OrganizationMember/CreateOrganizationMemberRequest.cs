using MediatR;
using OrganizationService.Shared.Messages.Commands.Organization;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using Rebus.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.OrganizationMember
{
    public class CreateOrganizationMemberRequest : IRequest<Guid>
    {
        public CreateOrganizationMemberRequest(
            string organizationId,
            string memberName,
            string memberEmail,
            int permission,
            DateTime changeDate,
            string changedBy
            )
        {
            OrganizationId = organizationId;
            MemberName = memberName;
            MemberEmail = memberEmail;
            Permission = permission;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        public string OrganizationId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public int Permission { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class CreateOrganizationMemberRequestHandler : IRequestHandler<CreateOrganizationMemberRequest, Guid>
    {
        private readonly IBus _bus;

        public CreateOrganizationMemberRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task<Guid> Handle(CreateOrganizationMemberRequest request, CancellationToken cancellationToken)
        {
            var command = new AddOrganizationMemberCommand(
                new Guid(request.OrganizationId),
                request.MemberName,
                request.MemberEmail,
                request.Permission,
                request.ChangeDate,
                request.ChangedBy);
            
            await _bus.Send(command);
            
            return await Task.FromResult(Guid.Empty);
        }
    }
}
