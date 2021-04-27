using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
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
    }
}
