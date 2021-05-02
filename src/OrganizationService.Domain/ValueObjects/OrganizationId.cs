using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class OrganizationId
    {
        public Guid Id { get; private set; }

        public static implicit operator Guid(OrganizationId self)  => self.Id;
        public OrganizationId(Guid id)
        {
            Id = id;
        }
        public OrganizationId(string id)
        {            
            if (Guid.TryParse(id, out Guid parsed) == false)
                throw new ArgumentException("String must be a guid value");
            Id = parsed;
        }
    }
}
