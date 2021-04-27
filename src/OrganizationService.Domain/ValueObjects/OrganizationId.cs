using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class OrganizationId
    {
        public Guid Id { get; private set; }

        public static implicit operator Guid(OrganizationId self)  => self.Id;
    }
}
