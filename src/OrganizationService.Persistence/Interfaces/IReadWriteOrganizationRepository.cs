using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Persistence.Interfaces
{
    public interface IReadWriteOrganizationRepository : IReadOnlyOrganizationRepository, IWriteOnlyOrganizationRepository
    {
    }
}
