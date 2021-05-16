using FluentAssertions;
using OrganizationService.Domain.ValueObjects;
using System;
using Xunit;

namespace DomainTest.ValueObjects
{
    public class AddressTest
    {
        [Theory]
        [InlineData("Testvej 2", "1234", "Good City", "Ireland" )]
        public void InitiateAddress_ValidInput_NoExtendedAddress_Success(string street, string postalCode, string city, string country)
        {
            // arrange // act
            var actual = new Address(street, postalCode, city, country);

            // assert
            actual.Street.Should().Be(street);
            actual.PostalCode.Should().Be(postalCode);
            actual.City.Should().Be(city);
            actual.Country.Should().Be(country);
            actual.StreetExtended.Should().Be(string.Empty);
        }

        [Theory]
        [InlineData("Test Strasse 9", "Extended address", "12345", "Gooder City", "Germany")]
        public void InitiateAddress_ValidInput_WithExtendedAddress_Success(string street, string streetExtended, string postalCode, string city, string country)
        {
            // arrange // act
            var actual = new Address(street, streetExtended, postalCode, city, country);

            // assert
            actual.Street.Should().Be(street);
            actual.PostalCode.Should().Be(postalCode);
            actual.City.Should().Be(city);
            actual.Country.Should().Be(country);
            actual.StreetExtended.Should().Be(streetExtended);
        }

        [Theory]
        [InlineData("", "12345", "Gooder City", "Germany")]
        [InlineData("Test Strasse 9", "", "Gooder City", "Germany")]
        [InlineData("Test Strasse 9", "12345", "", "Germany")]
        [InlineData("Test Strasse 9", "12345", "Gooder City", "")]
        public void InitiateAddress_BadInput_ThrowsException(string street, string postalCode, string city, string country)
        {
            // arrange //act
            Action actual = () => new Address(street, postalCode, city, country);

            //assert
            actual.Should().Throw<ArgumentException>();
        }
    }
}
