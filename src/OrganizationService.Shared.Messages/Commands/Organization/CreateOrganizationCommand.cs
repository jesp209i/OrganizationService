using System;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class CreateOrganizationCommand
    {
        public CreateOrganizationCommand(
            Guid id,
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
            Guard(id, name, street, postalCode, city, country, vatNumber, website, changeDate, changedBy);
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

        private void Guard(Guid id, string name, string street, string postalCode, string city, string country, string vatNumber, string website, DateTime changeDate, string changedBy)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException($"{nameof(street)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException($"{nameof(postalCode)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"{nameof(city)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException($"{nameof(country)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(vatNumber))
                throw new ArgumentException($"{nameof(vatNumber)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(website))
                throw new ArgumentException($"{nameof(website)} was not set in {nameof(CreateOrganizationCommand)}");
            if (changeDate == default)
                throw new ArgumentException($"{nameof(changeDate)} was not set in {nameof(CreateOrganizationCommand)}");
            if (string.IsNullOrWhiteSpace(changedBy))
                throw new ArgumentException($"{nameof(changedBy)} was not set in {nameof(CreateOrganizationCommand)}");
        }
        #region properties
        public Guid Id { get; set; }
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
        #endregion
    }
}
