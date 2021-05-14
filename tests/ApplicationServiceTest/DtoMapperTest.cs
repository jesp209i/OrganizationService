
using ApplicationServiceTest.Helpers;
using AutoFixture.Xunit2;
using FluentAssertions;
using OrganizationService.ApplicationService;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace ApplicationServiceTest
{
    public class DtoMapperTest
    {
        [Theory, AutoData]
        public void MapToDomain_Dto_ReturnsDomain(OrganizationDto organizationDto)
        {
            //Arrange
            var mapper = new DtoMapper();

            //Act
            var organization = mapper.Map(organizationDto).ToDomain();

            //Assert
            organization.Id.Id.Should().Be(organizationDto.Id);
            organization.Name.Name.Should().Be(organization.Name);
            organization.Address.Street.Should().Be(organizationDto.Street);
            organization.Address.StreetExtended.Should().Be(organizationDto.StreetExtended);
            organization.Address.PostalCode.Should().Be(organizationDto.PostalCode);
            organization.Address.City.Should().Be(organizationDto.City);
            organization.Address.Country.Should().Be(organizationDto.Country);
            organization.VatNumber.VatNumberString.Should().Be(organizationDto.VatNumber);
            organization.Website.Should().Be(organizationDto.Website);
            organization.ChangeDate.Should().Be(organizationDto.ChangeDate);
            organization.ChangedBy.Should().Be(organizationDto.ChangedBy);
        }

        [Theory, EntityAutoData]
        public void MapToDto_Domain_ReturnsDto(Organization organization)
        {
            //Arrange
            var mapper = new DtoMapper();

            //Act
            var organizationDto = mapper.Map(organization).ToDto();

            //Assert
            organization.Id.Id.Should().Be(organizationDto.Id);
            organization.Name.Name.Should().Be(organization.Name);
            organization.Address.Street.Should().Be(organizationDto.Street);
            organization.Address.StreetExtended.Should().Be(organizationDto.StreetExtended);
            organization.Address.PostalCode.Should().Be(organizationDto.PostalCode);
            organization.Address.City.Should().Be(organizationDto.City);
            organization.Address.Country.Should().Be(organizationDto.Country);
            organization.VatNumber.VatNumberString.Should().Be(organizationDto.VatNumber);
            organization.Website.Should().Be(organizationDto.Website);
            organization.ChangeDate.Should().Be(organizationDto.ChangeDate);
            organization.ChangedBy.Should().Be(organizationDto.ChangedBy);
        }

        [Theory, EntityAutoData]
        public void MapToOrganizationMemberDto_Domain_ReturnsOrganizationMemberDtoList(Organization organization)
        {
            //Arrange
            var mapper = new DtoMapper();
            var memberCount = organization.Members.Count;

            //Act
            var organizationMemberDtoList = mapper.Map(organization).ToOrganizationMembersDto();

            //Assert
            organizationMemberDtoList.Should().HaveCount(memberCount);
            organizationMemberDtoList.ToList()[0].Email.Should().Be(organization.Members[0].Email.ActualEmail);
        }
        [Theory, AutoData]
        public void MapToDto_InvalidInput_ThrowsException(Address address)
        {
            //Arrange
            var mapper = new DtoMapper();

            //Act
            Action actual = () => mapper.Map(address).ToDto();

            //Assert
            actual.Should().Throw<ArgumentException>();
        }
        [Theory, AutoData]
        public void MapToDomain_InvalidInput_ThrowsException(Address address)
        {
            //Arrange
            var mapper = new DtoMapper();

            //Act
            Action actual = () => mapper.Map(address).ToDomain();

            //Assert
            actual.Should().Throw<ArgumentException>();
        }

        [Theory, AutoData]
        public void ToOrganizationMembersDto_InvalidInput_ThrowsException(Address address)
        {
            //Arrange
            var mapper = new DtoMapper();

            //Act
            Action actual = () => mapper.Map(address).ToOrganizationMembersDto();

            //Assert
            actual.Should().Throw<ArgumentException>();
        }
    }
}
