using FluentAssertions;
using OrganizationService.Domain.ValueObjects;
using System;
using Xunit;

namespace DomainTest.ValueObjects
{
    public class OrganizationIdTest
    {
        [Fact]
        public void InstantiateOrganizationId_ValidGuid_Success()
        {
            // arrange
            var validGuid = Guid.NewGuid();
            
            //act
            var actual = new OrganizationId(validGuid);

            //assert
            actual.Id.Should().Be(validGuid);
        }

        [Fact]
        public void InstantiateOrganizationId_ValidGuidString_Success()
        {
            // arrange
            var expected = Guid.NewGuid();
            var validGuidString = expected.ToString();
            
            //act
            var actual = new OrganizationId(validGuidString);

            //assert
            actual.Id.Should().Be(expected);
        }

        [Fact]
        public void InstantiateOrganizationId_InvalidString_ThrowsException()
        {
            // arrange
            var expected = Guid.NewGuid();
            var invalidGuidString =  $"corrupted{expected}";

            //act
            Action actual = () => new OrganizationId(invalidGuidString);

            //assert
            actual.Should().Throw<ArgumentException>();
        }
    }
}
