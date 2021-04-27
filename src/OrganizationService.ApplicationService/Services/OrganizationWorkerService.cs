using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Services
{
    public class OrganizationWorkerService : OrganizationServiceBase, IOrganizationWorkerService
    {
        private IOrganizationPersistenceAdapter Persistence { get => _persistence as IOrganizationPersistenceAdapter;  }
        public OrganizationWorkerService(IOrganizationPersistenceAdapter persistence)
            : base(persistence) { }

        public async Task AddOrganization(OrganizationDto model)
        {
            var org = DtoMapper.Map(model).ToDomain();
            await Persistence.AddOrganization(org);
        }

        public async Task UpdateOrganization(OrganizationDto model)
        {
            var organization = DtoMapper.Map(model).ToDomain();
            await Persistence.UpdateOrganizationAsync(organization);
        }
    }
}
