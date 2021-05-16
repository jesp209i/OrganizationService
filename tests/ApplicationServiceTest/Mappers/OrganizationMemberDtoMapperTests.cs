using FluentAssertions;
using TestHelper.FixtureAttributes;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Mapper;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.ValueObjects;
using Xunit;

namespace ApplicationServiceTest.Mappers
{
    public class OrganizationMemberDtoMapperTests
    {
        [Theory, EntityAutoData]
        public void OrganizationMemberDtoMapper_Domain_ReturnsDto(OrganizationMember member)
        {
            //Arrange
            IMapper<OrganizationMember, OrganizationMemberDto> mapper = new OrganizationMemberDtoMapper();

            //Act
            var memberDto = mapper.Map(member).ToOutFormat();

            //Actual
            memberDto.Email.Should().Be(member.Email.ActualEmail);
            memberDto.Permission.Should().Be(member.Permission);
            memberDto.OrganizationId.Should().Be(member.OrganizationId.Id);
            memberDto.UserName.Should().Be(member.UserName);
        }
    }
}