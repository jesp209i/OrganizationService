using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Persistence.Entities;
using System;

namespace OrganizationService.Infrastructure
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
            if (!(_input is Organization))
                throw new ArgumentException("input must be an Organization to make an Entity.");

            var org = _input as Organization;
            var orgEntity = new OrganizationEntity {
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

            return orgEntity;
        }

        public Organization ToDomain()
        {
            if (!(_input is OrganizationEntity))
                throw new ArgumentException("input must be an OrganizationEntity to make a Domain Object.");

            var orgEntity = _input as OrganizationEntity;
            var orgName = new OrganizationName(orgEntity.Name);
            var orgAddress = new Address(orgEntity.Street, orgEntity.StreetExtended, orgEntity.PostalCode, orgEntity.City, orgEntity.Country);
            var orgVatNumber = new VatNumber(orgEntity.VatNumber);
            var org = new Organization(orgEntity.Id, orgName, orgAddress, orgVatNumber, orgEntity.Website)
            {
                ChangedBy = orgEntity.ChangedBy,
                ChangeDate = orgEntity.ChangeDate
            }
                ;

            return org;
        }
    }
}
