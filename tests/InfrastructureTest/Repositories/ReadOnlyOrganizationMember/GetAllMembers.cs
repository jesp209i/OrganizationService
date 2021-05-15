using AutoFixture.Xunit2;
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
using TestHelper.Infrastructure;
using Xunit;

namespace InfrastructureTest.Repositories.ReadOnlyOrganizationMember
{
    public class GetAllMembers
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAllMembers_ReturnsDomainList(List<OrganizationMemberEntity> members, OrganizationMember memberDomain)
        {
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(It.IsAny<OrganizationEntity>())).Returns(mapDomain.Object);
            var mapMemberDomain = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            mapMemberDomain.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(mapMemberDomain.Object);
            mapMemberDomain.Setup(x => x.ToOutFormat()).Returns(memberDomain);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadOnlyOrganizationMemberRepository(context ,mapMemberDomain.Object, mapDomain.Object);
            context.OrganizationMembers.AddRange(members);
            context.SaveChanges();
            // Act
            var hest = await repo.GetAllMembers();

            // Arrange
            hest.Should().HaveCount(members.Count);

        }
    }
}
