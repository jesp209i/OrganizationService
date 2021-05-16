using AutoFixture.Kernel;
using OrganizationService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
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
        private readonly List<string> _usedMails = new List<string>();
        public string GenerateRandomEmail()
        {
            string[] mailAliases = { "bubber", "jytte", "testhest", "andre", "jesper", "postkasse", "niller", "unique", "thesign", "mikey", "email" };
            string[] domains = { "example.com", "example.net", "example.org", "example.dk", "testhest.dk", "example.co.uk", "example.de" };
            int dIndex = new Random().Next(domains.Length);
            int maIndex = new Random().Next(mailAliases.Length);
            var mail = $"{mailAliases[maIndex]}@{domains[dIndex]}";
            if (_usedMails.Contains(mail)){
                mail = GenerateRandomEmail();
            }
            _usedMails.Add(mail);
            return mail;
        }
    }
}
