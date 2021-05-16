using FluentAssertions;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using System;
using TestHelper.FixtureAttributes;
using Xunit;

namespace DomainTest.ValueObjects
{
    public class OrganizationMemberTest
    {
        [Theory, EntityAutoData]
        public void NewInstance_EmailString_Success(OrganizationId orgId, Email mail, string userName, Permission permission)
        {
            //Act
            var member = new OrganizationMember(orgId,mail,userName,permission);
            //Assert
            member.OrganizationId.Id.Should().Be(orgId);
        }
        [Theory, EntityAutoData]
        public void NewInstance_NullEmail_ThrowsException(OrganizationId orgId, string userName, Permission permission)
        {
            //Act
            Action act = () => new OrganizationMember(orgId, null, userName, permission);
            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Theory, EntityAutoData]
        public void NewInstance_NullOrganizationId_ThrowsException(Email mail, string userName, Permission permission)
        {
            //Act
            Action act = () => new OrganizationMember(null, mail, userName, permission);
            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Theory, EntityAutoData]
        public void NewInstance_NoUserNameString_Success(OrganizationId orgId, Email mail, Permission permission)
        {
            //Act
            var member = new OrganizationMember(orgId, mail, string.Empty, permission);
            //Assert
            member.UserName.Should().Be(mail.ActualEmail);
        }
    }
}
