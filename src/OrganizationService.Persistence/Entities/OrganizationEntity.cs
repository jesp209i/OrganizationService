using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Persistence.Entities
{
    public class OrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string StreetExtended { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string VatNumber { get; set; }
        public string Website { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
