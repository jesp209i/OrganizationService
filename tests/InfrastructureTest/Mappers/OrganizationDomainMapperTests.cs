using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Mapper;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Domain;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationDomainMapperTests
    {
        [Theory, AutoData]
        public void Hest(OrganizationDto organizationDto)
        {
            //Arrange
            IMapper<OrganizationDto, Organization> mapper = new OrganizationDomainMapper();

            //Act
            var org = mapper.Map(organizationDto).ToOutFormat();

            //Actual
            //   --- OrganizationId
            org.Id.Id.Should().Be(organizationDto.Id);

            //   --- OrganizationName
            org.Name.Name.Should().Be(organizationDto.Name);

            //   --- Address
            org.Address.Street.Should().Be(organizationDto.Street);
            org.Address.StreetExtended.Should().Be(organizationDto.StreetExtended);
            org.Address.PostalCode.Should().Be(organizationDto.PostalCode);
            org.Address.City.Should().Be(organizationDto.City);
            org.Address.Country.Should().Be(organizationDto.Country);

            //   --- VatNumber
            org.VatNumber.VatNumberString.Should().Be(organizationDto.VatNumber);

            //   --- Website
            org.Website.Should().Be(organizationDto.Website);


            //   --- Meta
            org.ChangeDate.Should().Be(organizationDto.ChangeDate);
            org.ChangedBy.Should().Be(organizationDto.ChangedBy);
        }
    }
}
