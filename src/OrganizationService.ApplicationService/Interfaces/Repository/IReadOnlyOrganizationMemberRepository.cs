using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces.Repository
{
    public interface IReadOnlyOrganizationMemberRepository
    {
        Task<IEnumerable<OrganizationMember>> GetAllMembers();
        Task<IEnumerable<Organization>> GetUserOrganizationsByEmail(string email);
    }
}
