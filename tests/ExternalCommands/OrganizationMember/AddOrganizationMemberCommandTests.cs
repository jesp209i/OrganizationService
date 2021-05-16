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
    public class AddOrganizationMemberCommandTests
    {
        [Theory, AutoData]
        public void Instansiate_Success(Guid id, string name, string email, int permission, DateTime changeDate, string changedBy)
        {
            AddOrganizationMemberCommand command = new AddOrganizationMemberCommand(
                id,
                name,
                email,
                permission,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<AddOrganizationMemberCommand>();
        }

        [Theory, AutoData]
        public void Instansiate_WithoutPermission_Success(Guid id, string name, string email,  DateTime changeDate, string changedBy)
        {
            AddOrganizationMemberCommand command = new AddOrganizationMemberCommand(
                id,
                name,
                email,
                default,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<AddOrganizationMemberCommand>();
        }

        [Theory]
        [MemberData(nameof(AddOrganizationMemberCommand_BadInput_DataSource.TestData), MemberType = typeof(AddOrganizationMemberCommand_BadInput_DataSource))]
        public void Instansiate_MissingInput_ThrowsException(Guid id, string name, string email, int permission,DateTime changeDate, string changedBy)
        {
            Action act = () => new AddOrganizationMemberCommand(
                id,
                name,
                email,
                permission,
                changeDate,
                changedBy
                );

            act.Should().Throw<ArgumentException>();
        }
    }
    public static class AddOrganizationMemberCommand_BadInput_DataSource
    { 
        private static readonly List<object[]> _data = new List<object[]>()
        {
            new object[]{Guid.Empty, "name", "email", 1, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), string.Empty, "email", 1, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", string.Empty, 1, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "email", 1, default(DateTime), "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "email", 1, DateTime.Now, string.Empty }
        };

        public static IEnumerable<object[]> TestData { get { return _data; } }
    }
}
