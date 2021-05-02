using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.Enum;
using OrganizationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Services
{
    public class OrganizationReadOnlyService : OrganizationServiceBase, IOrganizationReadOnlyService
    {
        private IReadOnlyOrganizationPersistenceAdapter ReadOnlyPersistence { get => _persistence as IReadOnlyOrganizationPersistenceAdapter; }
        public OrganizationReadOnlyService(IReadOnlyOrganizationPersistenceAdapter persistence)
            : base(persistence) { }

        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var organizations = await ReadOnlyPersistence.GetAllOrganizations();
            return organizations.Select(x => DtoMapper.Map(x).ToDto()).ToList();
        }

        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            var org = await ReadOnlyPersistence.GetOrganizationAsync(id);
            return DtoMapper.Map(org).ToDto();
        }

        public async Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid id)
        {
            var org = await ReadOnlyPersistence.GetOrganizationAsync(id);
            var members = DtoMapper.Map(org).ToOrganizationMembersDto();
            return members;
        }

        public async Task<IEnumerable<OrganizationUserPermissionDto>> GetUserOrganizations(string email)
        {
            var orgs = await ReadOnlyPersistence.GetUserOrganizationsByEmail(email);
            return orgs.Select(x => new OrganizationUserPermissionDto { 
                OrganizationId = x.Organization.Id,
                OrganizationName = x.Organization.Name,
                Permission = (Permission) x.Permission
            } ).ToList();
        }
    }
}
