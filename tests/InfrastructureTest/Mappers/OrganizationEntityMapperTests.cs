using FluentAssertions;
using TestHelper.Infrastructure;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationEntityMapperTests
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationEntityMapper_Domain_ReturnsEntity(Organization organization, OrganizationMemberEntity orgMemberEntity)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMember, OrganizationMemberEntity>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMemberEntity);

            var sut = new OrganizationEntityMapper(memberMapper.Object);

            //Act
            var actual = sut.Map(organization).ToOutFormat();

            //Assert
            actual.Id.Should().Be(organization.Id.Id);
            actual.Name.Should().Be(organization.Name.Name);
            organization.Address.Should().BeEquivalentTo(actual, options => options.ExcludingMissingMembers());
            organization.VatNumber.Should().BeEquivalentTo(actual, options => options.ExcludingMissingMembers());
            actual.Website.Should().Be(organization.Website);
            actual.ChangeDate.Should().Be(organization.ChangeDate);
            actual.ChangedBy.Should().Be(organization.ChangedBy);
        }

        [Theory, EntityAutoData]
        public void OrganizationEntityMapper_DoaminWithMembers_ReturnsEntityIncludingMembers(Organization organization, OrganizationMemberEntity orgMemberEntity)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMember, OrganizationMemberEntity>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMemberEntity);

            var sut = new OrganizationEntityMapper(memberMapper.Object);

            //Act
            var memberCount = organization.Members.Count;
            var actual = sut.Map(organization).ToOutFormat();

            //Assert
            actual.Members.Should().HaveCount(memberCount);
            memberMapper.Verify(x=> x.Map(It.IsAny<OrganizationMember>()), Times.Exactly(memberCount));
        }

        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationEntityMapper_DomainWithoutMembers_ReturnsEntity(Organization organization, OrganizationMemberEntity orgMemberEntity)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMember, OrganizationMemberEntity>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMember>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMemberEntity);

            var sut = new OrganizationEntityMapper(memberMapper.Object);

            //Act
            var actual = sut.Map(organization).ToOutFormat();

            //Assert
            actual.Members.Should().HaveCount(0);

            memberMapper.Verify(x => x.Map(It.IsAny<OrganizationMember>()), Times.Never);
        }
    }
}
