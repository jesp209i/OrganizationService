using System;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class ChangeOrganizationVatNumberCommand
    {
        public ChangeOrganizationVatNumberCommand(Guid id, string vatNumber)
        {
            Guard(id, vatNumber);
            Id = id;
            VatNumber = vatNumber;
        }
        public Guid Id { get; set; }
        public string VatNumber { get; set; }

        private void Guard(Guid id, string vatNumber)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
            if (string.IsNullOrWhiteSpace(vatNumber))
                throw new ArgumentException($"{nameof(vatNumber)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
        }
    }
}
