using AutoFixture;
using AutoFixture.Xunit2;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Linq;

namespace TestHelper.ApplicationService
{
    public class EntityAutoDataAttribute : AutoDataAttribute
    {
        public EntityAutoDataAttribute() : base(() => new Fixture().Customize(new EntityAutoDataCustomization()))
        {
        }
    }

    public class EntityAutoDataCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(()=>
                new Email(GenerateRandomEmail())
                );

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                    .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customizations.Add(new OrganizationMemberGenerator());
        }
        public string GenerateRandomEmail()
        {
            string[] mailAliases = { "bubber", "jytte", "testhest", "andre", "jesper" };
            string[] domains = { "example.com", "example.net", "example.org", "example.dk", "testhest.dk" };
            int dIndex = new Random().Next(domains.Length);
            int maIndex = new Random().Next(mailAliases.Length);
            return $"{mailAliases[maIndex]}@{domains[dIndex]}";
        }
    }
}