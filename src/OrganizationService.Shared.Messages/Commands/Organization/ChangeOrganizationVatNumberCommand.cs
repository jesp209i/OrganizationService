using System;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class ChangeOrganizationVatNumberCommand
    {
        public ChangeOrganizationVatNumberCommand(Guid id, string vatNumber, DateTime changeDate, string changedBy)
        {
            Guard(id, vatNumber, changeDate, changedBy);
            Id = id;
            VatNumber = vatNumber;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
        public Guid Id { get; set; }
        public string VatNumber { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedBy { get; set; }

        private void Guard(Guid id, string vatNumber, DateTime changeDate, string changedBy)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
            if (string.IsNullOrWhiteSpace(vatNumber))
                throw new ArgumentException($"{nameof(vatNumber)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
            if (changeDate == default)
                throw new ArgumentException($"{nameof(changeDate)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
            if (string.IsNullOrWhiteSpace(changedBy))
                throw new ArgumentException($"{nameof(changedBy)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
        }
    }
}
