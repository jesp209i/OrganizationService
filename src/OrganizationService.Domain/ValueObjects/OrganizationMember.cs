using OrganizationService.Domain.Enum;
using System;

namespace OrganizationService.Domain.ValueObjects
{
    public class OrganizationMember
    {
        public OrganizationId OrganizationId { get; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public Permission Permission { get; private set; }

        public OrganizationMember(OrganizationId organizationId, string email, string userName, Permission permission = Permission.ReadOnly)
        {
            Guard(organizationId, email);
            OrganizationId = organizationId;
            Email = email.ToLowerInvariant();
            UserName = userName;
            if (string.IsNullOrWhiteSpace(userName))
                UserName = email.ToLowerInvariant();
            Permission = permission;
        }

        private void Guard(OrganizationId organizationId, string email)
        {
            if (organizationId == null || organizationId == Guid.Empty)
                throw new ArgumentException("Valid OrganizationId must be provided");
            if (email.Contains("@") == false || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email must be valid");
        }

        public void UpdatePermission(Permission permission)
        {
            Permission = permission;
        }
    }
}
