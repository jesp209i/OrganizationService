using System;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class ChangeOrganizationWebsiteCommand
    {
        public ChangeOrganizationWebsiteCommand(Guid id, string website, DateTime changeDate, string changedBy)
        {
            Guard(id, website, changeDate, changedBy);
            Id = id;
            Website = website;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public Guid Id { get; set; }
        public string Website { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }

        private void Guard(Guid id, string website, DateTime changeDate, string changedBy)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(ChangeOrganizationWebsiteCommand)}");
            if (string.IsNullOrWhiteSpace(website))
                throw new ArgumentException($"{nameof(website)} was not set in {nameof(ChangeOrganizationWebsiteCommand)}");
            if (changeDate == default)
                throw new ArgumentException($"{nameof(changeDate)} was not set in {nameof(ChangeOrganizationWebsiteCommand)}");
            if (string.IsNullOrWhiteSpace(changedBy))
                throw new ArgumentException($"{nameof(changedBy)} was not set in {nameof(ChangeOrganizationWebsiteCommand)}");
        }
    }
}
