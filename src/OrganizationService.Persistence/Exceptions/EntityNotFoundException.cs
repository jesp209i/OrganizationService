using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Persistence.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
