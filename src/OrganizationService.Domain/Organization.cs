using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationService.Domain
{
    public class Organization : Meta
    {
        public OrganizationId Id { get; private set; }
        public OrganizationName Name { get; private set; }
        public Address Address { get; private set; }
        public VatNumber VatNumber { get; private set; }
        public string Website { get; private set; }
        public IList<OrganizationMember> Members { get; private set; } = new List<OrganizationMember>();

        public Organization(Guid id, string name, string street, string streetExtended, string postalNumber, string city, string country, string vatNumber, string website, List<OrganizationMember> members, DateTime changeDate, string changedBy)
        {
            Id = new OrganizationId(id);
            Name = new OrganizationName(name);
            Address = new Address(street, streetExtended, postalNumber, city, country);
            VatNumber = new VatNumber(vatNumber);
            Website = website;
            Members = members;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        public Organization(Guid id, OrganizationName orgName, Address orgAddress, VatNumber orgVatNumber, string website, List<OrganizationMember> members, DateTime changeDate, string changedBy)
        {
            Id = new OrganizationId(id);
            Name = orgName;
            Address = orgAddress;
            VatNumber = orgVatNumber;
            Website = website;
            Members = members;
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }

        public void ChangeWebsite(string newWebsite, DateTime changeDate, string changedBy)
        {
            Website = newWebsite;
            UpdateMeta(changeDate, changedBy);
        }

        public void ChangeAddress(Address newAddress, DateTime changeDate, string changedBy)
        {
            Address = newAddress;
            UpdateMeta(changeDate, changedBy);
        }

        public void ChangeVatNumber(VatNumber newVatNumber, DateTime changeDate, string changedBy)
        {
            VatNumber = newVatNumber;
            UpdateMeta(changeDate, changedBy);
        }
        public void AddMember(string email, string name, Permission permission, DateTime changeDate, string changedBy)
        {
            var member = FindMemberByEmail(email);
            if (member != null)
                throw new ArgumentException($"Organization already has member with email: {email}");

            Members.Add(new OrganizationMember(Id, email, name, permission));
            UpdateMeta(changeDate, changedBy);
        }

        public void UpdateMemberPermission(string email, Permission permission, DateTime changeDate, string changedBy)
        {
            var member = FindMemberByEmail(email);
            if (member is null)
                throw new ArgumentException($"Organization does not have member with email {email}");
            
            member.UpdatePermission(permission);
            UpdateMeta(changeDate, changedBy);
        }

        private OrganizationMember FindMemberByEmail(string email)
        {
            email = email.ToLowerInvariant();
            var member = Members.Where(x => x.Email == email).FirstOrDefault();
            return member;
        }
    }
}
