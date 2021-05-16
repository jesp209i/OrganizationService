using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.Shared.Messages.Commands.Organization;
using System;
using System.Collections.Generic;
using Xunit;

namespace Messages.Organization
{
    public class ChangeOrganizationAddressCommandTests
    {
        [Theory, AutoData]
        public void Instansiate_Success(Guid id, string street, string streetExtended, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            ChangeOrganizationAddressCommand command = new ChangeOrganizationAddressCommand(
                id,
                street,
                streetExtended,
                postalCode,
                city,
                country,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<ChangeOrganizationAddressCommand>();
        }

        [Theory, AutoData]
        public void Instansiate_NoStreetExtended_Success(Guid id, string street, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            var command = new ChangeOrganizationAddressCommand(
                id,
                street,
                string.Empty,
                postalCode,
                city,
                country,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<ChangeOrganizationAddressCommand>();
        }

        [Theory]
        [MemberData(nameof(ChangeOrganizationAddressCommand_BadInput_DataSource.TestData), MemberType = typeof(ChangeOrganizationAddressCommand_BadInput_DataSource))]
        public void Instansiate_MissingInput_ThrowsException(Guid id, string street, string streetExtended, string postalCode, string city, string country, DateTime changeDate, string changedBy)
        {
            Action act = () => new ChangeOrganizationAddressCommand(
                id,
                street,
                streetExtended,
                postalCode,
                city,
                country,
                changeDate,
                changedBy
                );

            act.Should().Throw<ArgumentException>();
        }
    }
    public static class ChangeOrganizationAddressCommand_BadInput_DataSource
    { 
        private static readonly List<object[]> _data = new List<object[]>()
        {
            new object[]{Guid.Empty, "street", "StreetExtended", "postalCode", "city", "country", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), string.Empty, "StreetExtended", "postalCode", "city", "country", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "street", "StreetExtended", string.Empty, "city", "country", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "street", "StreetExtended", "postalCode", string.Empty, "country", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "street", "StreetExtended", "postalCode", "city", string.Empty, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "street", "StreetExtended", "postalCode", "city", "country", default(DateTime), "ChangedBy" },
            new object[]{Guid.NewGuid(), "street", "StreetExtended", "postalCode", "city", "country", DateTime.Now, string.Empty },


        };

        public static IEnumerable<object[]> TestData { get { return _data; } }
    }
}
