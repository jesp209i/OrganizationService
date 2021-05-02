using OrganizationService.ApplicationService.Models;
using System;

namespace OrganizationService.WebApi.Viewmodels
{
    public class Organization
    {
        public Organization(OrganizationDto organizationDto)
        {
            Id = organizationDto.Id;
            Name = organizationDto.Name;
            Street = organizationDto.Street;
            StreetExtended = organizationDto.StreetExtended;
            PostalCode = organizationDto.PostalCode;
            City = organizationDto.City;
            Country = organizationDto.Country;
            VatNumber = organizationDto.VatNumber;
            Website = organizationDto.Website;
            ChangeDate = organizationDto.ChangeDate;
            ChangedBy = organizationDto.ChangedBy;
        }
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
    }
}
