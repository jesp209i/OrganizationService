using AutoFixture;
using AutoFixture.Xunit2;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace TestHelper.Infrastructure
{
    public class OrganizationEntityNoMemberAutoData : AutoDataAttribute
    {
        public OrganizationEntityNoMemberAutoData() : base(() => new Fixture().Customize(new EntityAutoDataCustomization2()))
        {
        }
    }

    public class EntityAutoDataCustomization2 : ICustomization
    {
        public void Customize(IFixture fixture)
        {

            /*fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                    .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());*/
            fixture.Customize<OrganizationEntity>(x => x.Without(oe => oe.Members));
            fixture.Register(() =>
            {
                var members = new List<OrganizationMember>();
                var id = fixture.Create<OrganizationId>();
                var name = fixture.Create<OrganizationName>();
                var address = fixture.Create<Address>();
                var vatNumber = fixture.Create<VatNumber>();
                var website = fixture.Create<string>();
                var changeDate = fixture.Create<DateTime>();
                var changedBy = fixture.Create<string>();
                return new Organization(id, name, address, vatNumber, website, members, changeDate, changedBy);
            });
            fixture.Customizations.Add(new OrganizationMemberGenerator());
        }
    }
}