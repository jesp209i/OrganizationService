using System;

namespace OrganizationService.ApplicationService.Models
{
    public class ChangeOrganizationWebsiteDto : MetaDto
    {
        public Guid Id { get; set; }
        public string Website { get; set; }
    }
}
