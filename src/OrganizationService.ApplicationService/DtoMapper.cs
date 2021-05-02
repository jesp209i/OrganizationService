﻿using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrganizationService.ApplicationService
{
    public class DtoMapper
    {
        private readonly object _input;

        public static DtoMapper Map(object input) => new DtoMapper(input);
        private DtoMapper(object input)
        {
            _input = input;
        }

        public OrganizationDto ToDto()
        {
            return _input switch
            {
                Organization org => DomainToDto(org),
                OrganizationEntity entity => EntityToDto(entity),
                _ => throw new ArgumentException("input must be either domain or entity to make a Dto"),
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
                OrganizationEntity orgEntity => OrganizationMemberEntityToDto(orgEntity),
                _ => throw new ArgumentException("input must be either domain or entity to make a Dto"),
            };            
        

        private List<OrganizationMemberDto> OrganizationMemberEntityToDto(OrganizationEntity entity)
        {
            return entity.Members.Select(x => new OrganizationMemberDto { 
                OrganizationId = x.OrganizationId,
                UserName = x.UserName,
                Email = x.Email,
                Permission = (Permission)x.Permission
            }).ToList();
        }

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
        
        private OrganizationDto EntityToDto(OrganizationEntity entity)
        {
            var organizationDto = new OrganizationDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Street = entity.Street,
                StreetExtended = entity.StreetExtended,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country,
                VatNumber = entity.VatNumber,
                Website = entity.Website,
                ChangedBy = entity.ChangedBy,
                ChangeDate = entity.ChangeDate
            };

            return organizationDto;
        }
    }
}
