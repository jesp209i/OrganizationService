using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using InfrastructureTest.Helpers;
using OrganizationService.Domain;
using OrganizationService.Infrastructure;
using OrganizationService.Persistence.Entities;
using Xunit;

namespace InfrastructureTest
{
    public class PersistenceMapper_
    {
        public class ToEntity_
        {
            [Theory, EntityAutoData]
            public void ToEntity_Organization_ReturnsOrganizationEntity(Organization organization)
            {
                // arrange
                var mapOrganization = PersistenceMapper.Map(organization);

                //act
                var organizationEntity = mapOrganization.ToEntity();

                //assert
                organizationEntity.Should().BeOfType<OrganizationEntity>();
            }

            [Theory, EntityAutoData]
            public void ToEntity_Organization_ReturnsEquivalentOrganizationEntity(Organization organization)
            {
                //arrange
                var mapOrganization = PersistenceMapper.Map(organization);

                //act
                var organizationEntity = mapOrganization.ToEntity();

                //assert
                organizationEntity.Id.Should().Be(organization.Id);
                organizationEntity.Name.Should().Be(organization.Name);
                organizationEntity.Street.Should().Be(organization.Address.Street);
                organizationEntity.StreetExtended.Should().Be(organization.Address.StreetExtended);
                organizationEntity.PostalCode.Should().Be(organization.Address.PostalCode);
                organizationEntity.City.Should().Be(organization.Address.City);
                organizationEntity.Country.Should().Be(organization.Address.Country);
                organizationEntity.VatNumber.Should().Be(organization.VatNumber);
                organizationEntity.Website.Should().Be(organization.Website);
            }
        }

        public class ToDomain_
        {
            [Theory, EntityAutoData]
            public void ToDomain_OrganizationEntity_ReturnsOrganization(OrganizationEntity organizationEntity)
            {

                //arrange
                var mapEntity = PersistenceMapper.Map(organizationEntity);

                //act
                var organization = mapEntity.ToDomain();

                //assert
                organization.Should().BeOfType<Organization>();
            }

            [Theory, EntityAutoData]
            public void ToDomain_OrganizationEntity_ReturnsEquivalentOrganization(OrganizationEntity organizationEntity)
            {
                //arrange
                var mapEntity = PersistenceMapper.Map(organizationEntity);

                //act
                var organization = mapEntity.ToDomain();

                //assert
                organizationEntity.Id.Should().Be(organization.Id);
                organizationEntity.Name.Should().Be(organization.Name);
                organizationEntity.Street.Should().Be(organization.Address.Street);
                organizationEntity.StreetExtended.Should().Be(organization.Address.StreetExtended);
                organizationEntity.PostalCode.Should().Be(organization.Address.PostalCode);
                organizationEntity.City.Should().Be(organization.Address.City);
                organizationEntity.Country.Should().Be(organization.Address.Country);
                organizationEntity.VatNumber.Should().Be(organization.VatNumber);
                organizationEntity.Website.Should().Be(organization.Website);
            }
        }
    }
}
