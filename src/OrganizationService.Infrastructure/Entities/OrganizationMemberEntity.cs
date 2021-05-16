using OrganizationService.Domain.Enum;
using System;

namespace OrganizationService.Infrastructure.Entities
{
    public class OrganizationMemberEntity
    {
        public Guid OrganizationId { get; set; }
        public OrganizationEntity Organization { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Permission { get; set; }
        public OrganizationMemberEntity() {} // Empty constructor for EF Core
        public OrganizationMemberEntity(Guid organizationId, string email, string userName, Permission permission)
        {
            OrganizationId = organizationId;
            Email = email;
            UserName = userName;
            Permission = (int)permission;
        }
    }
}
