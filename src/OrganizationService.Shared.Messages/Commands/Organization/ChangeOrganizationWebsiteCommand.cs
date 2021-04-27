using System;

namespace OrganizationService.Shared.Messages.Commands.Organization
{
    public class ChangeOrganizationWebsiteCommand
    {
        public ChangeOrganizationWebsiteCommand(Guid id, string website)
        {
            Guard(id, website);
            Id = id;
            Website = website;
        }
        public Guid Id { get; set; }
        public string Website { get; set; }

        private void Guard(Guid id, string website)
        {
            if (id == default)
                throw new ArgumentException($"{nameof(id)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
            if (string.IsNullOrWhiteSpace(website))
                throw new ArgumentException($"{nameof(website)} was not set in {nameof(ChangeOrganizationVatNumberCommand)}");
        }
    }
}
