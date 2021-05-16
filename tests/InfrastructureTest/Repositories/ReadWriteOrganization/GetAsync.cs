using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Exceptions;
using OrganizationService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestHelper.FixtureAttributes;
using Xunit;

namespace InfrastructureTest.Repositories.ReadWriteOrganization
{
    public class GetAsync
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task GetAsync_Id_ReturnsOrganization(
            OrganizationEntity organizationEntity, 
            List<OrganizationEntity> list, 
            Organization organization, 
            Mock<IMapper<OrganizationMember, OrganizationMemberEntity>> mapMember,
            Mock<IMapper<Organization, OrganizationEntity>> entityMapper)
        {
            // Arrange
            list.Add(organizationEntity);
            var mapDomain = new Mock<IMapper<OrganizationEntity, Organization>>();
            mapDomain.Setup(x => x.Map(organizationEntity)).Returns(mapDomain.Object);
            mapDomain.Setup(x => x.ToOutFormat()).Returns(organization);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper.Object, mapDomain.Object, mapMember.Object);
            context.Organizations.AddRange(list);
            context.SaveChanges();

            // Act
            var Actual = await repo.GetAsync(organizationEntity.Id);

            // Arrange
            Actual.Should().BeOfType<Organization>();
        }
        [Theory, OrganizationEntityNoMemberAutoData]
        public void GetAsync_badId_ThrowsException(
            List<OrganizationEntity> list, 
            OrganizationEntity organizationEntity,
            Mock<IMapper<OrganizationMember, OrganizationMemberEntity>> mapMember,
            Mock<IMapper<Organization, OrganizationEntity>> entityMapper
            )
        {
            // Arrange
            var domainMapper = new Mock<IMapper<OrganizationEntity, Organization>>();
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper.Object, domainMapper.Object,mapMember.Object);
            context.Organizations.AddRange(list);
            context.SaveChanges();

            // Act
            Func<Task> act = async () => await repo.GetAsync(organizationEntity.Id);

            // Arrange
            act.Should().Throw<EntityNotFoundException>();
        }
    }
}
