using TestHelper.ApplicationService;
using FluentAssertions;
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
    public class ChangeOrganizationVatNumber
    {
        [Theory, EntityAutoData]
        public async Task ChangeOrganizationVatNumber_Success(
            ChangeOrganizationVatNumberDto changeDto,
            Organization organization,
            Mock<IMapper<OrganizationDto, Organization>> mapper)
        {
            //Arrange
            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.GetAsync(changeDto.Id)).ReturnsAsync(organization);

            repo.Setup(x => x.UpdateAsync(organization));

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            await service.ChangeOrganizationVatNumber(changeDto);

            //Assert
            organization.VatNumber.VatNumberString.Should().Be(changeDto.VatNumber);
        }
    }
}
