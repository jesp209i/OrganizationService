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
using TestHelper.Infrastructure;
using Xunit;
using OrganizationService.Infrastructure.Exceptions;

namespace InfrastructureTest.Repositories.ReadWriteOrganization
{
    public class UpdateOrganization
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task UpdateOrganization_Success(
            List<OrganizationEntity> list, 
            Organization organization, 
            OrganizationMember memb,
            Mock<IMapper<OrganizationMember, OrganizationMemberEntity>> mapMember,
            VatNumber newVatNumber)
        {
            // Arrange
            var orgMemberDomainMapper = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            
            orgMemberDomainMapper.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(orgMemberDomainMapper.Object);
            orgMemberDomainMapper.Setup(x => x.ToOutFormat()).Returns(memb);
            var mapDomain = new OrganizationDomainMapper(orgMemberDomainMapper.Object);
            var entityMapper = new OrganizationEntityMapper(mapMember.Object);
            var db = new InMemoryDb<OrganizationDbContext>();
            var context = new OrganizationDbContext(db.GetOptions());
            var repo = new ReadWriteOrganizationRepository(context, entityMapper, mapDomain, mapMember.Object);
            context.Organizations.AddRange(list);
            context.Organizations.Add(entityMapper.Map(organization).ToOutFormat());
            context.SaveChanges();

            // Act
            organization.ChangeVatNumber(newVatNumber, DateTime.Now, "TestChanger");
            await repo.UpdateAsync(organization);

            var actual = await context.Organizations.FindAsync(organization.Id.Id);

            // Assert
            actual.Id.Should().Be(organization.Id.Id);
            actual.VatNumber.Should().BeEquivalentTo(newVatNumber.VatNumberString);
            actual.ChangedBy.Should().Be("TestChanger");
        }

        [Theory, OrganizationEntityNoMemberAutoData]
        public async Task UpdateOrganization_badEntity_ThrowsException(
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
            act.Should().Throw<EntityNotFoundException>();
        }
    }
}
