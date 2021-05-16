using FluentAssertions;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TestHelper.ApplicationService;
using Xunit;

namespace DomainTest
{
    public class OrganizationTests
    {
        [Theory, EntityAutoData]
        public void AddMember_ExistingEmail_ThrowsException(Organization organization, OrganizationMemberDto member)
        {
            // Arrange
            member.Email = organization.Members[0].Email.ActualEmail;

            // Act
            Action act = () =>organization.AddMember(member.Email, member.UserName, member.Permission, member.ChangeDate, member.ChangedBy);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory, EntityAutoData]
        public void NewInstance_ValidInput_Success(Organization org)
        {
            // Arrange
            // Act
            var orgWithAllCtorParameters =
                new Organization(
                    org.Id.Id,
                    org.Name.Name,
                    org.Address.Street,
                    org.Address.StreetExtended,
                    org.Address.PostalCode,
                    org.Address.City,
                    org.Address.Country,
                    org.VatNumber.VatNumberString,
                    org.Website,
                    new List<OrganizationMember>(),
                    org.ChangeDate,
                    org.ChangedBy
                    );

            //Assert
            orgWithAllCtorParameters.Should().BeEquivalentTo(org, options => options.Excluding(x => x.Members));

        }
    }
}
