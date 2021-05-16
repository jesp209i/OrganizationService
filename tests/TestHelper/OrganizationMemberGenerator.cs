using AutoFixture.Kernel;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Reflection;

namespace TestHelper
{
    public class OrganizationMemberGenerator : ISpecimenBuilder
    {

        public object Create(object request, ISpecimenContext context)
        {
            var prop = request as PropertyInfo;

            if (prop != null && prop.Name == "Email" && prop.PropertyType == typeof(string))
                return GenerateRandomEmail();

            var pi = request as ParameterInfo;

            if (pi != null && pi.Name == "email" && pi.ParameterType == typeof(Email))
                return new Email(GenerateRandomEmail());

            return new NoSpecimen();

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
