using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.Domain.ValueObjects;
using System;
using Xunit;

namespace DomainTest.ValueObjects
{
    public class OrganizationNameTest
    {
        [Theory, AutoData]
        public void NewInstance_String_Success(string organizationName)
        {
            //Arrange
            //Act
            var name = new OrganizationName(organizationName);

            //Assert
            name.Name.Should().Be(organizationName);
        }

        [Fact]
        public void NewInstance_EmptyString_Fail()
        {
            //Arrange
            //Act
            Action name = () => new OrganizationName(string.Empty);

            //Assert
            name.Should().Throw<ArgumentException>();
        }
    }
}
