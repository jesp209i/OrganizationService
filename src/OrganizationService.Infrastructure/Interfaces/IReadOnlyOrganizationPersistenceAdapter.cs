using OrganizationService.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Interfaces
{
    public interface IReadOnlyOrganizationPersistenceAdapter: IPersistenceAdapter
    {
        Task<OrganizationEntity> GetOrganizationAsync(Guid id);
        Task<IEnumerable<OrganizationEntity>> GetAllOrganizations();
    }
}
