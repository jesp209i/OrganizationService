using OrganizationService.Domain;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganizationService.Infrastructure.Mapper
{
    public class PersistenceMapper
    {
        private readonly object _input;

        private PersistenceMapper(object input)
        {
            _input = input;
        }
        public static PersistenceMapper Map(object input) => new PersistenceMapper(input);

        public OrganizationEntity ToEntity()
        {
            if (_input is Organization == false)
                throw new ArgumentException("Input must be an Organization Domain object to create an entity");
            
            var org = _input as Organization;

            var members = IncludeMembers(org.Members);
            var orgEntity = new OrganizationEntity
            {
                Id = org.Id,
                Name = org.Name,
                Street = org.Address.Street,
                StreetExtended = org.Address.StreetExtended,
                PostalCode = org.Address.PostalCode,
                City = org.Address.City,
                Country = org.Address.Country,
                VatNumber = org.VatNumber,
                Website = org.Website,
                ChangedBy = org.ChangedBy,
                ChangeDate = org.ChangeDate,
                Members = members
            };

            return orgEntity;
        }

        public Organization ToDomain()
        {
            if (_input is OrganizationEntity == false)
                throw new ArgumentException("Input must be an Organization Entity to create a Domain Object");

            var orgEnt = _input as OrganizationEntity;

            var members = IncludeMembers(orgEnt.Members);
            var orgId = new OrganizationId(orgEnt.Id);
            var orgName = new OrganizationName(orgEnt.Name);
            var orgAddress = new Address(
                orgEnt.Street,
                orgEnt.StreetExtended,
                orgEnt.PostalCode,
                orgEnt.City,
                orgEnt.Country);
            var orgVAT = new VatNumber(orgEnt.VatNumber);
            var orgWebsite = orgEnt.Website;

            var organization = new Organization(orgId, orgName, orgAddress, orgVAT, orgWebsite, members, orgEnt.ChangeDate, orgEnt.ChangedBy);
            return organization;
        }


        private List<OrganizationMemberEntity> IncludeMembers(IEnumerable<OrganizationMember> list)
            => list.Select(x => MemberToEntity(x)).ToList();

        private List<OrganizationMember> IncludeMembers(IEnumerable<OrganizationMemberEntity> list)
            => list.Select(x => MemberToDomain(x)).ToList();

        public OrganizationMemberEntity MemberToEntity(OrganizationMember x)
        {
            return new OrganizationMemberEntity {
                OrganizationId = x.OrganizationId,
                Email = x.Email,
                UserName = x.UserName,
                Permission = (int)x.Permission
            };
        }

        public OrganizationMember MemberToDomain(OrganizationMemberEntity x)
        {
            return new OrganizationMember(
                new OrganizationId(x.OrganizationId),
                new Email(x.Email),
                x.UserName,
                (Permission)x.Permission
                );
        }
    }
}
