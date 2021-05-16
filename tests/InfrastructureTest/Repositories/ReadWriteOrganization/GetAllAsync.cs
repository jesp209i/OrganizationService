using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelper.FixtureAttributes;
using Xunit;

namespace InfrastructureTest.Repositories.ReadWriteOrganization
{
    public class GetAllAsync
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAllAsync_ReturnsDomainList(
            List<OrganizationEntity> organizations, 
            Organization org, 
            Mock<IMapper<OrganizationMember, OrganizationMemberEntity>> mapMember, 
            Mock<IMapper<Organization, OrganizationEntity>> entityMapper)
        {
            // Arrange
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(It.IsAny<OrganizationEntity>())).Returns(mapDomain.Object);
            mapDomain.Setup(x => x.ToOutFormat()).Returns(org);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper.Object, mapDomain.Object, mapMember.Object);
            context.Organizations.AddRange(organizations);
            context.SaveChanges();

            // Act
            var result = await repo.GetAllAsync();

            // Arrange
            result.Should().HaveCount(organizations.Count);
        }
    }
}

