using System;

namespace OrganizationService.Shared.Messages.Commands.OrganizationMember
{
    public class AddOrganizationMemberCommand
    {
        public AddOrganizationMemberCommand(
            Guid organizationId,
            string memberName,
            string memberEmail,
            int permission,
            DateTime changeDate,
            string changedBy
            )
        {
            Guard(organizationId, memberName, memberEmail, changeDate, changedBy);
            OrganizationId = organizationId;
            MemberName = memberName;
            MemberEmail = memberEmail;
            Permission = permission;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        private void Guard(Guid organizationId, string memberName, string memberEmail, DateTime changeDate, string changedBy)
        {
            if (organizationId == default)
                throw new ArgumentException($"{nameof(organizationId)} was not set in {nameof(AddOrganizationMemberCommand)}");
            if (string.IsNullOrWhiteSpace(memberName))
                throw new ArgumentException($"{nameof(memberName)} was not set in {nameof(AddOrganizationMemberCommand)}");
            if (string.IsNullOrWhiteSpace(memberEmail))
                throw new ArgumentException($"{nameof(memberEmail)} was not set in {nameof(AddOrganizationMemberCommand)}");
            if (changeDate == default)
                throw new ArgumentException($"{nameof(changeDate)} was not set in {nameof(AddOrganizationMemberCommand)}");
            if (string.IsNullOrWhiteSpace(changedBy))
                throw new ArgumentException($"{nameof(changedBy)} was not set in {nameof(AddOrganizationMemberCommand)}");
        }
        #region properties
        public Guid OrganizationId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public int Permission { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }
        #endregion
    }
}
