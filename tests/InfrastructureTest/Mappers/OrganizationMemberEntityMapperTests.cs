using FluentAssertions;
using TestHelper.Infrastructure;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationMemberEntityMapperTests
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationMemberEntityMapper_Domain_ReturnsEntity(OrganizationMember organization)
        {
            //Arrange
            IMapper<OrganizationMember, OrganizationMemberEntity> sut = new OrganizationMemberEntityMapper();

            //Act
            var actual = sut.Map(organization).ToOutFormat();

            //Assert
            actual.OrganizationId.Should().Be(organization.OrganizationId.Id);
            actual.Email.Should().Be(organization.Email.ActualEmail);
            actual.UserName.Should().Be(organization.UserName);
            actual.Permission.Should().Be((int)organization.Permission);
        }
    }
}
