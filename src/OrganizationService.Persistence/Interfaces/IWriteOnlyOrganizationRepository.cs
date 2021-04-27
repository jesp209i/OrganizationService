
using OrganizationService.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.Persistence.Interfaces
{
    public interface IWriteOnlyOrganizationRepository
    {
        Task AddOrganization(OrganizationEntity organization);
        Task UpdateAsync(OrganizationEntity updatedOrganization);
    }
}
