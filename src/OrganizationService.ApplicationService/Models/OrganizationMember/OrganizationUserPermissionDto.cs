using OrganizationService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.ApplicationService.Models.OrganizationMember
{
    public class OrganizationUserPermissionDto
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public Permission Permission { get; set; }
    }
}
