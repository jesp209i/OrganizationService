using FluentAssertions;
using InfrastructureTest.Helpers;
using Moq;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using Xunit;

namespace InfrastructureTest.Mappers
{
    public class OrganizationDomainMapperTests
    {
        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationDomainMapper_Entity_ReturnsDomain(OrganizationEntity organizationEntity, OrganizationMember orgMember)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMember);

            var sut = new OrganizationDomainMapper(memberMapper.Object);

            //Act
            var actual = sut.Map(organizationEntity).ToOutFormat();

            //Assert
            actual.Id.Should().BeEquivalentTo(organizationEntity, options => options.ExcludingMissingMembers());
            actual.Name.Should().BeEquivalentTo(organizationEntity, options => options.ExcludingMissingMembers());
            actual.Address.Should().BeEquivalentTo(organizationEntity, options => options.ExcludingMissingMembers());
            actual.VatNumber.Should().BeEquivalentTo(organizationEntity, options => options.ExcludingMissingMembers());
            actual.Website.Should().Be(organizationEntity.Website);
            actual.ChangeDate.Should().Be(organizationEntity.ChangeDate);
            actual.ChangedBy.Should().Be(organizationEntity.ChangedBy);
        }

        [Theory, EntityAutoData]
        public void OrganizationDomainMapper_EntityWithMembers_ReturnsDomainIncludingMembers(OrganizationEntity organizationEntity, OrganizationMember orgMember)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMember);

            var sut = new OrganizationDomainMapper(memberMapper.Object);

            //Act
            var memberCount = organizationEntity.Members.Count;
            var actual = sut.Map(organizationEntity).ToOutFormat();

            //Assert
            actual.Members.Should().HaveCount(memberCount);
            memberMapper.Verify(x=> x.Map(It.IsAny<OrganizationMemberEntity>()), Times.Exactly(memberCount));
        }

        [Theory, OrganizationEntityNoMemberAutoData]
        public void OrganizationDomainMapper_EntityWithoutMembers_ReturnsDomain(OrganizationEntity organizationEntity, OrganizationMember orgMember)
        {
            //Arrange
            var memberMapper = new Mock<IMapper<OrganizationMemberEntity, OrganizationMember>>();
            memberMapper.Setup(x => x.Map(It.IsAny<OrganizationMemberEntity>())).Returns(memberMapper.Object);
            memberMapper.Setup(x => x.ToOutFormat()).Returns(orgMember);

            var sut = new OrganizationDomainMapper(memberMapper.Object);

            //Act
            var actual = sut.Map(organizationEntity).ToOutFormat();

            //Assert
            actual.Members.Should().HaveCount(0);

            memberMapper.Verify(x => x.Map(It.IsAny<OrganizationMemberEntity>()), Times.Never);
        }
    }
}
