using MediatR;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.Organization
{
    public class ChangeOrganizationWebsiteRequest : IRequest<Guid>
    {
        public ChangeOrganizationWebsiteRequest(string id, string website, DateTime changeDate, string changedBy)
        {
            Id = id;
            Website = website;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public string Id { get; set; }
        public string Website { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class ChangeOrganizationWebsiteRequestHandler : IRequestHandler<ChangeOrganizationWebsiteRequest, Guid>
    {
        private readonly IBus _bus;

        public ChangeOrganizationWebsiteRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task<Guid> Handle(ChangeOrganizationWebsiteRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangeOrganizationWebsiteCommand(
                new Guid(request.Id),
                request.Website,
                request.ChangeDate,
                request.ChangedBy
                );
            await _bus.Send(command);

            return await Task.FromResult(Guid.Empty);
        }
    }
}
