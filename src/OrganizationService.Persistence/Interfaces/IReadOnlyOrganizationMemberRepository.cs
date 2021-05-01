using OrganizationService.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationService.Persistence.Interfaces
{
    public interface IReadOnlyOrganizationMemberRepository
    {
        Task<IEnumerable<OrganizationMemberEntity>> GetAllMembers();
        Task<IEnumerable<OrganizationMemberEntity>> GetUserOrganizationsByEmail(string email);
    }
}
