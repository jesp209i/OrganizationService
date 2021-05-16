using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTests
{
    public class UserControllerTest
    {
        [Theory, AutoData]
        public async Task GetUserOrganizations_validEmail_returnOrganizationDtoList(List<OrganizationDto> list, string email)
        {
            //Arrange
            var readOnlyService = new Mock<IOrganizationReadOnlyService>();
            readOnlyService.Setup(x => x.GetUserOrganizations(email)).ReturnsAsync(list);
            var system = new UserController(readOnlyService.Object);

            //Act
            var result = await system.GetUserOrganizations(email);

            //Assert
            result.Should().HaveCount(list.Count);

        }
    }
}
