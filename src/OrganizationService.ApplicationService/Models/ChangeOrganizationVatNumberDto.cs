using System;

namespace OrganizationService.ApplicationService.Models
{
    public class ChangeOrganizationVatNumberDto : MetaDto
    {
        public Guid Id { get; set; }
        public string VatNumber { get; set; }
    }
}