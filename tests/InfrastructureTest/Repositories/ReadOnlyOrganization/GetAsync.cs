using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Exceptions;
using OrganizationService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelper.Infrastructure;
using Xunit;

namespace InfrastructureTest.Repositories.ReadOnlyOrganization
{
    public class GetAsync
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAsync_Id_ReturnsOrganization(List<OrganizationEntity> list, OrganizationEntity organizationEntity, Organization organization)
        {
            // Arrange
            list.Add(organizationEntity);
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(organizationEntity)).Returns(mapDomain.Object);
            mapDomain.Setup(x => x.ToOutFormat()).Returns(organization);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadOnlyOrganizationRepository(context, mapDomain.Object);
            context.Organizations.AddRange(list);
            context.SaveChanges();

            // Act
            var Actual = await repo.GetAsync(organizationEntity.Id);

            // Arrange
            Actual.Should().BeOfType<Organization>();
        }
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAsync_badId_ThrowsException(List<OrganizationEntity> list, OrganizationEntity organizationEntity)
        {
            // Arrange
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadOnlyOrganizationRepository(context, mapDomain.Object);
            context.Organizations.AddRange(list);
            context.SaveChanges();

            // Act
            Func<Task> act = async () => await repo.GetAsync(organizationEntity.Id);

            // Arrange
            act.Should().Throw<EntityNotFoundException>();
        }
    }
}
