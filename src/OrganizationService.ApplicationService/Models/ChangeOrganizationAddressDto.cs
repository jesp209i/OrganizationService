using System;

namespace OrganizationService.ApplicationService.Models
{
    public class ChangeOrganizationAddressDto : MetaDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string StreetExtended { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}