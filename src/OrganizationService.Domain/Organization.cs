using OrganizationService.Domain.ValueObjects;
using System;

namespace OrganizationService.Domain
{
    public class Organization : Meta
    {
        public Guid Id { get; private set; }
        public OrganizationName Name { get; private set; }
        public Address Address { get; private set; }
        public VatNumber VatNumber { get; private set; }
        public string Website { get; private set; }
        
        public Organization(Guid id, string name, string street, string streetExtended, string postalNumber, string city, string country, string vatNumber, string website)
        {
            Id = id;
            Name = new OrganizationName(name);
            Address = new Address(street, streetExtended, postalNumber, city, country);
            VatNumber = new VatNumber(vatNumber);
            Website = website;
        }

        public Organization(Guid id, OrganizationName orgName, Address orgAddress, VatNumber orgVatNumber, string website)
        {
            Id = id;
            Name = orgName;
            Address = orgAddress;
            VatNumber = orgVatNumber;
            Website = website;
        }
    }
}
