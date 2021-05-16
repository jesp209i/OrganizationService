using System;

namespace OrganizationService.Infrastructure.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
