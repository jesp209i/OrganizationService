using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class ChangeOrganizationAddressCommand
    {
        public ChangeOrganizationAddressCommand(Guid id, string street, string streetExtended, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            Guard(id, street, postalCode, city, country, changeDate, changedBy);
            Id = id;
            Street = street;
            StreetExtended = streetExtended;
            PostalCode = postalCode;
            City = city;
            Country = country;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        public Guid Id { get; set; }
        public string Street { get; set; }
        public string StreetExtended { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }

        private void Guard(Guid id, string street, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException($"{nameof(street)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException($"{nameof(postalCode)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"{nameof(city)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException($"{nameof(country)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (changeDate == default)
                throw new ArgumentException($"{nameof(changeDate)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
            if (string.IsNullOrWhiteSpace(changedBy))
                throw new ArgumentException($"{nameof(changedBy)} was not set in {nameof(ChangeOrganizationAddressCommand)}");
        }
    }
}
