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

namespace InfrastructureTest.Repositories.ReadOnlyOrganizationMember
{
    public class GetUserOrganizationByEmail
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetUserOrganizationByEmail_ReturnsDomainList(List<OrganizationEntity> organizations, OrganizationMemberEntity memberEntity, Organization organization)
        {
            var orgMembers = new List<OrganizationMemberEntity>();
            // Arrange
            organizations.ForEach(x =>
                orgMembers.Add(
                    new OrganizationMemberEntity
                    {
                        OrganizationId = x.Id,
                        Organization = x,
                        Email = memberEntity.Email,
                        Permission = memberEntity.Permission,
                        UserName = memberEntity.UserName
                    }));

            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(It.IsAny<OrganizationEntity>())).Returns(mapDomain.Object);
            mapDomain.Setup(x => x.ToOutFormat()).Returns(organization);
            var mapMemberDomain = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            mapMemberDomain.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(mapMemberDomain.Object);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadOnlyOrganizationMemberRepository(context, mapMemberDomain.Object, mapDomain.Object);
            context.OrganizationMembers.AddRange(orgMembers);
            context.SaveChanges();
            // Act
            var hest = await repo.GetUserOrganizationsByEmail(memberEntity.Email);

            // Arrange
            hest.Should().HaveCount(3);

        }
    }
}
