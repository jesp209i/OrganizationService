using FluentAssertions;
using InfrastructureTest.Helpers;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationEntityMapperTests
    {
        [Theory, EntityAutoData]
        public void Hest(Organization organization)
        {
            //Arrange
            var map = new Mock<IMapper<OrganizationMember, OrganizationMemberEntity>>();
            map.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(map.Object);
            map.Setup(x => x.ToOutFormat()).Returns(new OrganizationMemberEntity());

            IMapper<Organization, OrganizationEntity> mapper = new OrganizationEntityMapper(map.Object);

            //Act
            var memberCount = organization.Members.Count;
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

            //   --- MemberCount
            orgDto.Members.Should().HaveCount(memberCount);

            //   --- Meta
            orgDto.ChangeDate.Should().Be(organization.ChangeDate);
            orgDto.ChangedBy.Should().Be(organization.ChangedBy);
        }
    }
}
