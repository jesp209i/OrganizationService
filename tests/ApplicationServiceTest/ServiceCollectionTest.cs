using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OrganizationService.ApplicationService.Extensions;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Extensions;
using Xunit;

namespace ApplicationServiceTest
{
    public class ServiceCollectionTest
    {
        [Fact]
        public void DI_ForWorker_Success()
        {
            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x[Constants.EnvironmentVariables.DatabaseConnectionString]).Returns("testing");

            //Act
            ServiceProvider provider = new ServiceCollection()
                .AddApplicationServices()
                .AddInfrastructure(config.Object)
                .BuildServiceProvider();

            //Assert
            Assert.IsType<OrganizationWorkerService>(provider.GetService<IOrganizationWorkerService>());
        }

        [Fact]
        public void DI_ForWebApi_Success()
        {
            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x[Constants.EnvironmentVariables.DatabaseConnectionString]).Returns("testing");

            //Act
            ServiceProvider provider = new ServiceCollection()
                .AddReadOnlyApplicationServices()
                .AddReadOnlyInfrastructure(config.Object)
                .BuildServiceProvider();

            //Assert
            Assert.IsType<OrganizationReadOnlyService>(provider.GetService<IOrganizationReadOnlyService>());
        }
    }
}
