using MediatR;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter.Handlers.Organization
{
    public class CreateOrganizationRequest : IRequest<Guid>
    {
        public CreateOrganizationRequest(
            string id,
            string name,
            string street,
            string streetExtended,
            string postalCode,
            string city,
            string country,
            string vatNumber,
            string website,
            DateTime changeDate,
            string changedBy
            )
        {
            Id = id;
            Name = name;
            Street = street;
            StreetExtended = streetExtended;
            PostalCode = postalCode;
            City = city;
            Country = country;
            VatNumber = vatNumber;
            Website = website;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string StreetExtended { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string VatNumber { get; set; }
        public string Website { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
    }

    public class CreateOrganizationRequestHandler : IRequestHandler<CreateOrganizationRequest, Guid>
    {
        private readonly IBus _bus;

        public CreateOrganizationRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task<Guid> Handle(CreateOrganizationRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateOrganizationCommand(
                new Guid(request.Id),
                request.Name,
                request.Street,
                request.StreetExtended,
                request.PostalCode,
                request.City,
                request.Country,
                request.VatNumber,
                request.Website,
                request.ChangeDate,
                request.ChangedBy);
            
            await _bus.Send(command);
            
            return await Task.FromResult(Guid.Empty);
        }
    }
}
