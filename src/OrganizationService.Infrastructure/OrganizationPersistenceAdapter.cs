using OrganizationService.Domain;
using OrganizationService.Infrastructure.Interfaces;
using OrganizationService.Persistence.Entities;
using OrganizationService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure
{
    public class OrganizationPersistenceAdapter : IOrganizationPersistenceAdapter
    {
        private readonly IReadWriteOrganizationRepository _organizationRepository;
        

        public OrganizationPersistenceAdapter(IReadWriteOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public async Task AddOrganization(Organization organization)
        {
            var ent = PersistenceMapper.Map(organization).ToEntity();
            
            await _organizationRepository.AddOrganization(ent);
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizations()
        {
            var organizationEntities = await GetAllAsync();
            return organizationEntities.Select(x => PersistenceMapper.Map(x).ToDomain()).ToList();
        }

        public async Task<Organization> GetOrganizationAsync(Guid id)
        {
            var organizationEntity = await GetAsync(id);
            return PersistenceMapper.Map(organizationEntity).ToDomain();
        }

        private async Task<OrganizationEntity> GetAsync(Guid id) 
            => await _organizationRepository.GetAsync(id);

        private async Task<IEnumerable<OrganizationEntity>> GetAllAsync()
            => await _organizationRepository.GetAllAsync();

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            var orgEntity = PersistenceMapper.Map(organization).ToEntity();
            await _organizationRepository.UpdateAsync(orgEntity);
        }
    }
}
