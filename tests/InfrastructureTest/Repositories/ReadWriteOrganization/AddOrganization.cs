using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Infrastructure.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelper.FixtureAttributes;
using Xunit;

namespace InfrastructureTest.Repositories.ReadWriteOrganization
{
    public class AddOrganization
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task AddOrganization_Success(
            Organization organization,
            OrganizationMemberEntity memb,
            Mock<IMapper<OrganizationMemberEntity, OrganizationMember>> orgMemberDomainMapper
            )

        {
            // Arrange
            var mapMember = new Mock<IMapper<OrganizationMember, OrganizationMemberEntity>>();

            mapMember.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(mapMember.Object);
            mapMember.Setup(x => x.ToOutFormat()).Returns(memb);
            var mapDomain = new OrganizationDomainMapper(orgMemberDomainMapper.Object);
            var entityMapper = new OrganizationEntityMapper(mapMember.Object);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper, mapDomain, mapMember.Object);

            // Act

            await repo.AddOrganization(organization);

            var actual = await context.Organizations.FindAsync(organization.Id.Id);

            // Assert
            actual.Id.Should().Be(organization.Id.Id);
            organization.Address.Should().BeEquivalentTo(actual, options => options.ExcludingMissingMembers());
            
        }

        [Theory, OrganizationEntityNoMemberAutoData]
        public void UpdateOrganization_badEntity_ThrowsException(
            List<OrganizationEntity> list,
            Organization organization,
            Mock<IMapper<OrganizationMember, OrganizationMemberEntity>> mapMember,
            Mock<IMapper<Organization, OrganizationEntity>> entityMapper)
        {
            // Arrange
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper.Object, mapDomain.Object, mapMember.Object);
            context.Organizations.AddRange(list);
            context.SaveChanges();

            // Act
            Func<Task> act = async () => await repo.UpdateAsync(organization);

            // Arrange
            act.Should().Throw<Exception>();
        }
    }
}