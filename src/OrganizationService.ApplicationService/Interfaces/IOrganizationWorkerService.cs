using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces
{
    public interface IOrganizationWorkerService
    {
        Task AddOrganization(OrganizationDto organization);
        Task ChangeOrganizationAddress(ChangeOrganizationAddressDto changeModel);
        Task ChangeOrganizationVatNumber(ChangeOrganizationVatNumberDto changeModel);
        Task ChangeOrganizationWebsite(ChangeOrganizationWebsiteDto changeModel);
        Task AddOrganizationMember(OrganizationMemberDto newMember);
        Task ChangeOrganizationMemberPermission(ChangeOrganizationMemberPermissionDto changePermission);
    }
}
