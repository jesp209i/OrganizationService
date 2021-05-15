using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelper.Infrastructure;
using Xunit;

namespace InfrastructureTest.Repositories.ReadOnlyOrganization
{
    public class GetAllAsync
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAllAsync_ReturnsDomainList(List<OrganizationEntity> organizations, Organization org)
        {
            // Arrange
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(It.IsAny<OrganizationEntity>())).Returns(mapDomain.Object);
            mapDomain.Setup(x => x.ToOutFormat()).Returns(org);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadOnlyOrganizationRepository(context, mapDomain.Object);
            context.Organizations.AddRange(organizations);
            context.SaveChanges();

            // Act
            var hest = await repo.GetAllAsync();

            // Arrange
            hest.Should().HaveCount(organizations.Count);
        }
    }
}

