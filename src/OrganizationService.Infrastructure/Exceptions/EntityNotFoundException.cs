using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Infrastructure.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
