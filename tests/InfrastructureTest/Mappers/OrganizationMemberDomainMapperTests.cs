using FluentAssertions;
using TestHelper.FixtureAttributes;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationMemberDomainMapperTests
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationMemberDomainMapper_Entity_ReturnsDomain(OrganizationMemberEntity organizationEntity)
        {
            //Arrange
            IMapper<OrganizationMemberEntity, OrganizationMember> sut = new OrganizationMemberDomainMapper();

            //Act
            var actual = sut.Map(organizationEntity).ToOutFormat();

            //Assert
            actual.OrganizationId.Id.Should().Be(organizationEntity.OrganizationId);
            actual.Email.ActualEmail.Should().Be(organizationEntity.Email);
            actual.UserName.Should().Be(organizationEntity.UserName);
            actual.Permission.Should().Be(organizationEntity.Permission);
        }
    }
}
