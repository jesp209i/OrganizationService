using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.ApplicationService.Interfaces.Repository
{
    public interface IReadWriteOrganizationRepository : IReadOnlyOrganizationRepository, IWriteOnlyOrganizationRepository
    {
    }
}
