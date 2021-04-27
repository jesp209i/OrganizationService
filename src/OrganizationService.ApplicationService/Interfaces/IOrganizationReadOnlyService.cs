using OrganizationService.ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces
{
    public interface IOrganizationReadOnlyService
    {
        Task<OrganizationDto> GetOrganization(Guid id);
        Task<IEnumerable<OrganizationDto>> GetAll();
    }
}
