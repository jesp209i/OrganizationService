using TestHelper.ApplicationService;
using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.ApplicationService.Services;
using OrganizationService.Domain;
using OrganizationService.Domain.Enum;
using System;
using System.Threading.Tasks;
using Xunit;


namespace ApplicationServiceTest.Services.OrganizationWorker
{
    public class ChangeOrganizationMemberPermission
    {
        [Theory, EntityAutoData]
        public async Task ChangeOrganizationMemberPermission_Success(
            Organization organization,
            Mock<IMapper<OrganizationDto, Organization>> mapper)
        {
            //Arrange
            var member1 = organization.Members[0];
            var changeDto = new ChangeOrganizationMemberPermissionDto {
                OrganizationId = organization.Id.Id,
                Email = member1.Email.ActualEmail,
                Permission = Permission.SuperAdmin,
                ChangeDate = DateTime.Now,
                ChangedBy = "tester"
            };

            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.GetAsync(changeDto.OrganizationId)).ReturnsAsync(organization);

            repo.Setup(x => x.UpdateAsync(organization));

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            await service.ChangeOrganizationMemberPermission(changeDto);
            var actualMember = organization.Members[0];

            //Assert
            organization.ChangedBy.Should().Be(changeDto.ChangedBy);
            organization.ChangeDate.Should().Be(changeDto.ChangeDate);

            actualMember.Email.ActualEmail.Should().Be(changeDto.Email);
            actualMember.Permission.Should().Be(changeDto.Permission);
        }

        [Theory, EntityAutoData]
        public void ChangeOrganizationMemberPermission_Fail(
            ChangeOrganizationMemberPermissionDto changeDto,
            Organization organization,
            Mock<IMapper<OrganizationDto, Organization>> mapper)
        {
            //Arrange
            var member1 = organization.Members[0];
            changeDto.OrganizationId = organization.Id.Id;

            var repo = new Mock<IReadWriteOrganizationRepository>();
            repo.Setup(x => x.GetAsync(changeDto.OrganizationId)).ReturnsAsync(organization);

            //repo.Setup(x => x.UpdateAsync(organization));

            var service = new OrganizationWorkerService(repo.Object, mapper.Object);

            //Act
            Func<Task> actual = async () => await service.ChangeOrganizationMemberPermission(changeDto);


            //Assert
            actual.Should().Throw<ArgumentException>();
        }
    }
}
