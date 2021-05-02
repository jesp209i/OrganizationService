using MediatR;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.Organization
{
    public class ChangeOrganizationAddressRequest : IRequest<Guid>
    {
        public ChangeOrganizationAddressRequest(string id, string street, string streetExtended, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            Id = id;
            Street = street;
            StreetExtended = streetExtended;
            PostalCode = postalCode;
            City = city;
            Country = country;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public string Id { get; set; }
        public string Street { get; set; }
        public string StreetExtended { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class ChangeOrganizationAddressRequestHandler : IRequestHandler<ChangeOrganizationAddressRequest, Guid>
    {
        private readonly IBus _bus;

        public ChangeOrganizationAddressRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task<Guid> Handle(ChangeOrganizationAddressRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangeOrganizationAddressCommand(
                new Guid(request.Id),
                request.Street,
                request.StreetExtended,
                request.PostalCode,
                request.City,
                request.Country,
                request.ChangeDate,
                request.ChangedBy
                );

            await _bus.Send(command);

            return await Task.FromResult(Guid.Empty);
        }

    }
}
