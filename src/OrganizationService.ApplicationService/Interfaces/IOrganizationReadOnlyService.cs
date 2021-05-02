using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces
{
    public interface IOrganizationReadOnlyService
    {
        Task<OrganizationDto> GetOrganization(Guid id);
        Task<IEnumerable<OrganizationDto>> GetAll();
        Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid id);
        Task<IEnumerable<OrganizationUserPermissionDto>> GetUserOrganizations(string email);
    }
}
