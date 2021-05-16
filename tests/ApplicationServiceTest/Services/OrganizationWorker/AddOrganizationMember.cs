using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using TestHelper.FixtureAttributes;


namespace ApplicationServiceTest.Services.OrganizationWorker
{
    public class AddOrganizationMember
    {
        [Theory, EntityAutoData]
        public async Task AddOrganizationMember_Success(
            Organization organization,
            OrganizationMemberDto changeDto,
            Mock<IMapper<OrganizationDto, Organization>> mapper)
        {
            //Arrange
            changeDto.OrganizationId = organization.Id.Id;
            OrganizationMember addedMember = null;

            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.GetAsync(changeDto.OrganizationId)).ReturnsAsync(organization);

            repo.Setup(x => x.UpdateAsync(organization)).Callback(() => addedMember = organization.Members.First(x=> x.Email.ActualEmail == changeDto.Email));

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            await service.AddOrganizationMember(changeDto);

            //Assert
            organization.ChangedBy.Should().Be(changeDto.ChangedBy);
            organization.ChangeDate.Should().Be(changeDto.ChangeDate);

            addedMember.Email.ActualEmail.Should().Be(changeDto.Email);
            addedMember.UserName.Should().Be(changeDto.UserName);
        }
    }
}
