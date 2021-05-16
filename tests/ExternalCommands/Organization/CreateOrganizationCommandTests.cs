using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.Shared.Messages.Commands.Organization;
using System;
using System.Collections.Generic;
using Xunit;

namespace Messages.Organization
{
    public class CreateOrganizationCommandTests
    {
        [Theory, AutoData]
        public void Instansiate_Success(Guid id, string name, string street, string streetExtended, string postalCode, string city, string country, string vatNumber, string website, DateTime changeDate, string changedBy)
        {
            CreateOrganizationCommand command = new CreateOrganizationCommand(
                id,
                name,
                street,
                streetExtended,
                postalCode,
                city,
                country,
                vatNumber,
                website,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<CreateOrganizationCommand>();
        }

        [Theory, AutoData]
        public void Instansiate_NoStreetExtended_Success(Guid id, string name, string street, string postalCode, string city, string country, string vatNumber, string website, DateTime changeDate, string changedBy)
        {
            var command = new CreateOrganizationCommand(
                id,
                name,
                street,
                string.Empty,
                postalCode,
                city,
                country,
                vatNumber,
                website,
                changeDate,
                changedBy
                );

            command.Should().BeOfType<CreateOrganizationCommand>();
        }

        [Theory]
        [MemberData(nameof(CreateOrganizationCommand_BadInput_DataSource.TestData), MemberType = typeof(CreateOrganizationCommand_BadInput_DataSource))]
        public void Instansiate_MissingInput_ThrowsException(Guid id, string name, string street, string streetExtended, string postalCode, string city, string country, string vatNumber, string website, DateTime changeDate, string changedBy)
        {
            Action act = () => new CreateOrganizationCommand(
                id,
                name,
                street,
                streetExtended,
                postalCode,
                city,
                country,
                vatNumber,
                website,
                changeDate,
                changedBy
                );

            act.Should().Throw<ArgumentException>();
        }
    }
    public static class CreateOrganizationCommand_BadInput_DataSource 
    { 
        private static readonly List<object[]> _data = new List<object[]>()
        {
            new object[]{Guid.Empty, "name", "street", "StreetExtended", "postalCode", "city", "country", "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), string.Empty, "street", "StreetExtended", "postalCode", "city", "country", "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", string.Empty, "StreetExtended", "postalCode", "city", "country", "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", string.Empty, "city", "country", "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", string.Empty, "country", "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", "city", string.Empty, "vatnumber", "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", "city", "country", string.Empty, "website", DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", "city", "country", "vatnumber", string.Empty, DateTime.Now, "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", "city", "country", "vatnumber", "website", default(DateTime), "ChangedBy" },
            new object[]{Guid.NewGuid(), "name", "street", "StreetExtended", "postalCode", "city", "country", "vatnumber", "website", DateTime.Now, string.Empty },

        };

        public static IEnumerable<object[]> TestData { get { return _data; } }
    }
}
