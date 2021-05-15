using TestHelper.ApplicationService;
using Moq;
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
    {
        [Theory, EntityAutoData]
        public async Task AddOrganization_Success(OrganizationDto organizationDto, Organization organization)
        {
            //Arrange
            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.AddOrganization(It.IsAny<Organization>()));

            var mapper = new Mock<IMapper<OrganizationDto,Organization>>();
            mapper.Setup(m => m.Map(organizationDto)).Returns(mapper.Object);
            mapper.Setup(m => m.ToOutFormat()).Returns(organization);

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            await service.AddOrganization(organizationDto);

            //Assert
            repo.Verify(x => x.AddOrganization(organization), Times.Once);
        }
    }    
}
