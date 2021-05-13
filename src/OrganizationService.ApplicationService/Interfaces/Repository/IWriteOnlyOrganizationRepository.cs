using OrganizationService.Domain;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces.Repository
{
    public interface IWriteOnlyOrganizationRepository
    {
        Task AddOrganization(Organization organization);
        Task UpdateAsync(Organization updatedOrganization);
    }
}
