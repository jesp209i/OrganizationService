using OrganizationService.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizationService.ApplicationService.Models.OrganizationMember
{
    public class OrganizationMemberDto : MetaDto
    {
        [Required]
        public Guid OrganizationId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public Permission Permission { get; set; }
    }
}
