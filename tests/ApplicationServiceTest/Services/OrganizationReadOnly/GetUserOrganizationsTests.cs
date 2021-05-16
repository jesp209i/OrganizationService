using TestHelper.FixtureAttributes;
using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationServiceTest.Services.OrganizationReadOnly
{
    public class GetUserOrganizationsTests
    {
        [Theory, EntityAutoData]
        public async Task GetOrganization_ReturnsOrganizationDto(
            Email mail,
            List<Organization> organizations,
            Mock<IMapper<OrganizationMember, OrganizationMemberDto>> memberMap,
            Mock<IReadOnlyOrganizationRepository> orgRepo
            )
        {
            //Arrange            
            var memberRepo = new Mock<IReadOnlyOrganizationMemberRepository>();
            memberRepo.Setup(x => x.GetUserOrganizationsByEmail(mail)).ReturnsAsync(organizations);

            var orgMap = new Mock<IMapper<Organization, OrganizationDto>>();
            orgMap.Setup(x => x.Map(It.IsAny<Organization>())).Returns(orgMap.Object);
            orgMap.Setup(x => x.ToOutFormat()).Returns(new OrganizationDto ());

            var service = new OrganizationReadOnlyService(orgRepo.Object, memberRepo.Object, orgMap.Object, memberMap.Object);


            //Act
            var actual = await service.GetUserOrganizations(mail);

            //Assert
            actual.Should().HaveCount(organizations.Count);
        }
    }
}
