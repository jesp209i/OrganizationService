using OrganizationService.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces.Repository
{
    public interface IReadOnlyOrganizationRepository
    {
        Task<Organization> GetAsync(Guid id);
        Task<IEnumerable<Organization>> GetAllAsync();
    }
}
