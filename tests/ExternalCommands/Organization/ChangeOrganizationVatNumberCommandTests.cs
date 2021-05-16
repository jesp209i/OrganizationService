using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.Shared.Messages.Commands.Organization;
using System;
using System.Collections.Generic;
using Xunit;

namespace Messages.Organization
{
    public class ChangeOrganizationVatNumberCommandTests
    {
        [Theory, AutoData]
        public void Instansiate_Success(Guid id, string vatNumber, DateTime changeDate, string changedBy)
        {
            ChangeOrganizationVatNumberCommand command = new ChangeOrganizationVatNumberCommand(
                id,
                vatNumber,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<ChangeOrganizationVatNumberCommand>();
        }

        [Theory]
        [MemberData(nameof(ChangeOrganizationVatNumberCommand_BadInput_DataSource.TestData), MemberType = typeof(ChangeOrganizationVatNumberCommand_BadInput_DataSource))]
        public void Instansiate_MissingInput_ThrowsException(Guid id, string vatNumber, DateTime changeDate, string changedBy)
        {
            Action act = () => new ChangeOrganizationVatNumberCommand(
                id,
                vatNumber,
                changeDate,
                changedBy
                );

            act.Should().Throw<ArgumentException>();
        }
    }
    public static class ChangeOrganizationVatNumberCommand_BadInput_DataSource
    { 
        private static readonly List<object[]> _data = new List<object[]>()
        {
            new object[]{Guid.Empty, "vatnumber", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), string.Empty, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "vatNumber", default(DateTime), "ChangedBy" },
            new object[]{Guid.NewGuid(), "VatNumber", DateTime.Now, string.Empty },
        };

        public static IEnumerable<object[]> TestData { get { return _data; } }
    }
}
