using FluentAssertions;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DomainTest.ValueObjects
{
    public class EmailTest
    {
        [Fact]
        public void NewInstance_EmailString_Success()
        {
            //Arrange
            var emailString = "testmail@hello.de";
            //Act
            var email = new Email(emailString);

            //Assert
            email.ActualEmail.Should().Be(emailString);
        }

        [Fact]
        public void NewInstance_NotEmptyString_ThrowsExecption()
        {
            //Arrange
            var notEmailString = "Im not an email";
            //Act
            Action email = () => new Email(notEmailString);

            //Assert
            
            email.Should().Throw<ArgumentException>();
        }
    }
}
