using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Collections.Generic;

namespace OrganizationService.ApplicationService.Mapper
{
    public class OrganizationDomainMapper : AbstractMapper<OrganizationDto, Organization>, IMapper<OrganizationDto, Organization>
    {
        public override Organization ToOutFormat()
        {
            var orgName = new OrganizationName(_input.Name);
            var orgAddress = new Address(_input.Street, _input.StreetExtended, _input.PostalCode, _input.City, _input.Country);
            var orgVatNumber = new VatNumber(_input.VatNumber);
            var organization = new Organization(_input.Id, orgName, orgAddress, orgVatNumber, _input.Website, new List<OrganizationMember>(), _input.ChangeDate, _input.ChangedBy);

            return organization;
        }
    }
}
