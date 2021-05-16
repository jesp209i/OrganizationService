using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using Moq;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Shared.Messages.Commands.Organization;
using OrganizationService.Worker.Handlers.Organization;
using System.Threading.Tasks;
using Xunit;

namespace WorkerTest
{
    public class CreateOrganization
    {

        [Theory, AutoData]
        public async Task Handle_Success(CreateOrganizationCommand orgDto, Mock<ILogger<CreateOrganizationCommandHandler>> logger)
        {
            //Arrange
            var workerService = new Mock<IOrganizationWorkerService>();
            workerService.Setup(x=> x.AddOrganization(It.IsAny<OrganizationDto>()));
            var system = new CreateOrganizationCommandHandler(workerService.Object, logger.Object);

            //Act
            await system.Handle(orgDto);

            //Assert
            workerService.Verify(x => x.AddOrganization(It.IsAny<OrganizationDto>()), Times.Once);
        }


    }
}
