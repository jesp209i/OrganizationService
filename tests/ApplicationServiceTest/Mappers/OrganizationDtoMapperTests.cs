using FluentAssertions;
using ApplicationServiceTest.Helpers;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Mapper;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Domain;
using Xunit;

namespace ApplicationServiceTest.Mappers
{
    public class OrganizationDtoMapperTests
    {
        [Theory, EntityAutoData]
        public void OrganizationDtoMapper_Domain_ReturnsDto(Organization organization)
        {
            //Arrange
            IMapper<Organization, OrganizationDto> mapper = new OrganizationDtoMapper();

            //Act
            var orgDto = mapper.Map(organization).ToOutFormat();

            //Actual
            //   --- OrganizationId
            orgDto.Id.Should().Be(organization.Id.Id);
            
            //   --- OrganizationName
            orgDto.Name.Should().Be(organization.Name.Name);
                        
            //   --- Address
            orgDto.Street.Should().Be(organization.Address.Street);
            orgDto.StreetExtended.Should().Be(organization.Address.StreetExtended);
            orgDto.PostalCode.Should().Be(organization.Address.PostalCode);
            orgDto.City.Should().Be(organization.Address.City);
            orgDto.Country.Should().Be(organization.Address.Country);

            //   --- VatNumber
            orgDto.VatNumber.Should().Be(organization.VatNumber.VatNumberString);
            
            //   --- Website
            orgDto.Website.Should().Be(organization.Website);


            //   --- Meta
            orgDto.ChangeDate.Should().Be(organization.ChangeDate);
            orgDto.ChangedBy.Should().Be(organization.ChangedBy);
        }
    }
}
