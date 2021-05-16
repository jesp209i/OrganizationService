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
    public class ChangeOrganizationAddress
    {

        [Theory, AutoData]
        public async Task Handle_Success(ChangeOrganizationAddressCommand orgDto, Mock<ILogger<ChangeOrganizationAddressCommandHandler>> logger)
        {
            //Arrange
            var workerService = new Mock<IOrganizationWorkerService>();
            workerService.Setup(x=> x.ChangeOrganizationAddress(It.IsAny<ChangeOrganizationAddressDto>()));
            var system = new ChangeOrganizationAddressCommandHandler(workerService.Object, logger.Object);

            //Act
            await system.Handle(orgDto);

            //Assert
            workerService.Verify(x => x.ChangeOrganizationAddress(It.IsAny<ChangeOrganizationAddressDto>()), Times.Once);
        }
    }
}
