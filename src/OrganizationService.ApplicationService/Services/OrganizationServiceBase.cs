using OrganizationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.ApplicationService.Services
{
    public abstract class OrganizationServiceBase
    {
        protected readonly IPersistenceAdapter _persistence;

        public OrganizationServiceBase(IPersistenceAdapter persistence)
        {
            _persistence = persistence;
        }
    }
}
