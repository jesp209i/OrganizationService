using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.Shared.Messages.Commands.Organization;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using System;
using System.Collections.Generic;
using Xunit;

namespace Messages.OrganizationMember
{
    public class ChangeOrganizationMemberPermissionCommandTests
    {
        [Theory, AutoData]
        public void Instansiate_Success(Guid id, string email, int permission, DateTime changeDate, string changedBy)
        {
            ChangeOrganizationMemberPermissionCommand command = new ChangeOrganizationMemberPermissionCommand(
                id,
                email,
                permission,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<ChangeOrganizationMemberPermissionCommand>();
        }

        [Theory, AutoData]
        public void Instansiate_WithoutPermission_Success(Guid id, string email,  DateTime changeDate, string changedBy)
        {
            ChangeOrganizationMemberPermissionCommand command = new ChangeOrganizationMemberPermissionCommand(
                id,
                email,
                default,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<ChangeOrganizationMemberPermissionCommand>();
        }

        [Theory]
        [MemberData(nameof(ChangeOrganizationMemberPermissionCommand_BadInput_DataSource.TestData), MemberType = typeof(ChangeOrganizationMemberPermissionCommand_BadInput_DataSource))]
        public void Instansiate_MissingInput_ThrowsException(Guid id, string email, int permission,DateTime changeDate, string changedBy)
        {
            Action act = () => new ChangeOrganizationMemberPermissionCommand(
                id,
                email,
                permission,
                changeDate,
                changedBy
                );

            act.Should().Throw<ArgumentException>();
        }
    }
    public static class ChangeOrganizationMemberPermissionCommand_BadInput_DataSource
    { 
        private static readonly List<object[]> _data = new List<object[]>()
        {
            new object[]{Guid.Empty, "email", 1, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), string.Empty, 1, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "email", 1, default(DateTime), "ChangedBy" },
            new object[]{Guid.NewGuid(), "email", 1, DateTime.Now, string.Empty }
        };

        public static IEnumerable<object[]> TestData { get { return _data; } }
    }
}
