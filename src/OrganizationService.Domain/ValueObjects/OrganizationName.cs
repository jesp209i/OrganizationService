using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class OrganizationName
    {
        public string Name { get; private set; }

        public OrganizationName(string name)
        {
            NameGuard(name);
            Name = name;
        }

        private void NameGuard(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name), "Organization Name must be specified.");
        }

        public static implicit operator string(OrganizationName self) => self.Name;
    }
}
