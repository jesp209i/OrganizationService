using AutoFixture;
using AutoFixture.Xunit2;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestHelper.FixtureAttributes
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
            fixture.Register(() =>
            new Email(GenerateRandomEmail())
            );
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                    .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customizations.Add(new OrganizationMemberGenerator());
        }
        private readonly List<string> _usedMails = new List<string>();
        public string GenerateRandomEmail()
        {
            string[] mailAliases = { "bubber", "jytte", "testhest", "andre", "jesper", "postkasse", "niller", "unique", "thesign", "mikey", "email" };
            string[] domains = { "example.com", "example.net", "example.org", "example.dk", "testhest.dk", "example.co.uk", "example.de" };
            int dIndex = new Random().Next(domains.Length);
            int maIndex = new Random().Next(mailAliases.Length);
            var mail = $"{mailAliases[maIndex]}@{domains[dIndex]}";
            if (_usedMails.Contains(mail))
            {
                mail = GenerateRandomEmail();
            }
            _usedMails.Add(mail);
            return mail;
        }
    }
}