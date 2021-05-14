using ApplicationServiceTest.Helpers;
using AutoFixture.Xunit2;
using Moq;
using OrganizationService.ApplicationService;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationServiceTest.Services.OrganizationWorker
{
    public class AddOrganization
    {/*
        [Theory, EntityAutoData]
        public async Task OrganizationAdded(OrganizationDto organizationDto, Organization organization)
        {
            //Arrange
            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.AddOrganization(It.IsAny<Organization>()));

            var mapper = new Mock<IMapper<Organization>>();
            mapper.Setup(m => m.Map(organizationDto));
            mapper.Setup(m => m.ToDomain()).Returns(organization);

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            await service.AddOrganization(organizationDto);

            //Assert
            repo.Verify(x => x.AddOrganization(organization), Times.Once);
        }
        */
    }    
}
