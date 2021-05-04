using OrganizationService.Domain.Enum;
using System;

namespace OrganizationService.Domain.ValueObjects
{
    public class OrganizationMember
    {
        public OrganizationId OrganizationId { get; }
        public Email Email { get; private set; }
        public string UserName { get; private set; }
        public Permission Permission { get; private set; }

        public OrganizationMember(OrganizationId organizationId, Email email, string userName, Permission permission = Permission.ReadOnly)
        {
            Guard(organizationId, email);
            OrganizationId = organizationId;
            Email = email;
            UserName = userName;
            if (string.IsNullOrWhiteSpace(userName))
                UserName = email.ActualEmail.ToLowerInvariant();
            Permission = permission;
        }

        private void Guard(OrganizationId organizationId, Email email)
        {
            if (organizationId is null)
                throw new ArgumentNullException($"{typeof(OrganizationId)} needed");
            if (email is null)
                throw new ArgumentNullException($"{typeof(Email)} needed");
        }

        public void UpdatePermission(Permission permission)
        {
            Permission = permission;
        }
    }
}
