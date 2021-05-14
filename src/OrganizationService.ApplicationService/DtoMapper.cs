using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationService.ApplicationService
{
    public class DtoMapper
    {
        private object _input;

        public DtoMapper Map(object input)
        {
            _input = input;
            return this;
        }

        public OrganizationDto ToDto()
        {
            return _input switch
            {
                Organization org => DomainToDto(org),
                _ => throw new ArgumentException("input must be domain to make a Dto"),
            };
        }

        public Organization ToDomain()
        {
            if (!(_input is OrganizationDto))
                throw new ArgumentException("input must be an OrganizationDto to make a Domain Object.");
            var orgEntity = _input as OrganizationDto;
            
            return DtoToDomain(orgEntity);
        }

        private Organization DtoToDomain(OrganizationDto dto)
        {
            var orgName = new OrganizationName(dto.Name);
            var orgAddress = new Address(dto.Street, dto.StreetExtended, dto.PostalCode, dto.City, dto.Country);
            var orgVatNumber = new VatNumber(dto.VatNumber);
            var organization = new Organization(dto.Id, orgName, orgAddress, orgVatNumber, dto.Website, new List<OrganizationMember>(), dto.ChangeDate, dto.ChangedBy);

            return organization;
        }

        public IEnumerable<OrganizationMemberDto> ToOrganizationMembersDto() =>
            _input switch
            {
                Organization org => OrganizationMemberDomainToDto(org),
                _ => throw new ArgumentException("input must be either domain or entity to make a Dto"),
            };            
        

        private List<OrganizationMemberDto> OrganizationMemberDomainToDto(Organization org)
        {
            return org.Members.Select(x => new OrganizationMemberDto
            {
                OrganizationId = x.OrganizationId,
                UserName = x.UserName,
                Email = x.Email,
                Permission = x.Permission
            }).ToList();
        }

        private OrganizationDto DomainToDto(Organization org)
        {
            var organizationDto = new OrganizationDto
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
                ChangeDate = org.ChangeDate
            };

            return organizationDto;
        }
    }
}
