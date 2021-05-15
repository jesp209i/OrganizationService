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
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationServiceTest.Services.OrganizationReadOnly
{
    public class GetAllTests
    {
        [Theory, EntityAutoData]
        public async Task GetAll_ReturnsDtoList(
            List<Organization> orgs, 
            Mock<IMapper<OrganizationMember, OrganizationMemberDto>> memberMap, 
            Mock<IReadOnlyOrganizationMemberRepository> memberRepo
            )
        {
            //Arrange
            var orgRepo = new Mock<IReadOnlyOrganizationRepository>();
            orgRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(orgs);

            var orgMap = new Mock<IMapper<Organization, OrganizationDto>>();
            orgMap.Setup(x => x.Map(It.IsAny<Organization>())).Returns(orgMap.Object);
            orgMap.Setup(x => x.ToOutFormat()).Returns(new OrganizationDto());

            var organizationCount = orgs.Count;
            var service = new OrganizationReadOnlyService(orgRepo.Object, memberRepo.Object, orgMap.Object, memberMap.Object);


            //Act
            var actual = await service.GetAll();

            //Assert
            actual.Should().HaveCount(organizationCount);
        }
    }
}
