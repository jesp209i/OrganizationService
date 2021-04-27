using OrganizationService.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationService.Persistence.Interfaces
{
    public interface IReadOnlyOrganizationRepository
    {
        Task<OrganizationEntity> GetAsync(Guid id);
        Task<IEnumerable<OrganizationEntity>> GetAllAsync();
    }
}
