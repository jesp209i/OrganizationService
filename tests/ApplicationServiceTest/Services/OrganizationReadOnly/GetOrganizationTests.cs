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
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationServiceTest.Services.OrganizationReadOnly
{
    public class GetOrganizationTests
    {
        [Theory, EntityAutoData]
        public async Task GetOrganization_ReturnsOrganizationDto(
            Organization organization,
            Mock<IMapper<OrganizationMember, OrganizationMemberDto>> memberMap,
            Mock<IReadOnlyOrganizationMemberRepository> memberRepo
            )
        {
            //Arrange
            var orgId = Guid.NewGuid();
            var orgRepo = new Mock<IReadOnlyOrganizationRepository>();
            orgRepo.Setup(x => x.GetAsync(orgId)).ReturnsAsync(organization);

            var orgMap = new Mock<IMapper<Organization, OrganizationDto>>();
            orgMap.Setup(x => x.Map(It.IsAny<Organization>())).Returns(orgMap.Object);
            orgMap.Setup(x => x.ToOutFormat()).Returns(new OrganizationDto { Id = orgId});

            var service = new OrganizationReadOnlyService(orgRepo.Object, memberRepo.Object, orgMap.Object, memberMap.Object);


            //Act
            var actual = await service.GetOrganization(orgId);

            //Assert
            actual.Id.Should().Be(orgId);
        }
    }
}
