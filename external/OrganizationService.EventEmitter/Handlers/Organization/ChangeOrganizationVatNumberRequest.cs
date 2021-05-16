using MediatR;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.Organization
{
    public class ChangeOrganizationVatNumberRequest : IRequest<Guid>
    {
        public ChangeOrganizationVatNumberRequest(string id, string vatNumber, DateTime changeDate, string changedBy)
        {
            Id = id;
            VatNumber = vatNumber;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public string Id { get; set; }
        public string VatNumber { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class ChangeOrganizationVatNumberRequestHandler : IRequestHandler<ChangeOrganizationVatNumberRequest, Guid>
    {
        private readonly IBus _bus;

        public ChangeOrganizationVatNumberRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task<Guid> Handle(ChangeOrganizationVatNumberRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangeOrganizationVatNumberCommand(
                new Guid(request.Id),
                request.VatNumber,
                request.ChangeDate,
                request.ChangedBy
                );
            await _bus.Send(command);

            return await Task.FromResult(Guid.Empty);
        }
    }
}
