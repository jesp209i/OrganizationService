using ApplicationServiceTest.Helpers;
using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationServiceTest.Services.OrganizationReadOnly
{
    public class GetOrganizationMembersTest
    {
        [Theory, EntityAutoData]
        public async Task GetOrganizationMembers_ReturnsMemberDtoList(
            Organization org,
            Mock<IReadOnlyOrganizationRepository> orgRepo,
            Mock<IMapper<Organization, OrganizationDto>> orgMap
            )
        {
            //Arrange
            Mock<IReadOnlyOrganizationMemberRepository> memberRepo = new Mock<IReadOnlyOrganizationMemberRepository>();
            Mock<IMapper<OrganizationMember, OrganizationMemberDto>> memberMap = new Mock<IMapper<OrganizationMember, OrganizationMemberDto>>();
            orgRepo.Setup(x => x.GetAsync(org.Id)).ReturnsAsync(org);

            orgMap.Setup(x => x.Map(It.IsAny<Organization>())).Returns(orgMap.Object);
            orgMap.Setup(x => x.ToOutFormat()).Returns(new OrganizationDto());

            memberMap.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(memberMap.Object);
            memberMap.Setup(x => x.ToOutFormat()).Returns(new OrganizationMemberDto());

            var service = new OrganizationReadOnlyService(orgRepo.Object, memberRepo.Object, orgMap.Object, memberMap.Object);

            //Act
            var actual = await service.GetOrganizationMembers(org.Id);

            //Assert
            actual.Should().HaveCount(org.Members.Count);
        }
    }
}
