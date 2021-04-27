using OrganizationService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Interfaces
{
    public interface IOrganizationPersistenceAdapter: IPersistenceAdapter
    {
        Task AddOrganization(Organization organization);
        Task<Organization> GetOrganizationAsync(Guid id);
        Task<IEnumerable<Organization>> GetAllOrganizations();
        Task UpdateOrganizationAsync(Organization organization);
    }
}
