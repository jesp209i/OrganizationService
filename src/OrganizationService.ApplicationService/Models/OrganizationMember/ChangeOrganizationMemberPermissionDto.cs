using OrganizationService.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizationService.ApplicationService.Models.OrganizationMember
{
    public class ChangeOrganizationMemberPermissionDto : MetaDto
    {
        [Required]
        public Guid OrganizationId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Permission Permission { get; set; }
    }
}
