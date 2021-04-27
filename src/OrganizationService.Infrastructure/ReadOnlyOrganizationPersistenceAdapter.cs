using OrganizationService.Infrastructure.Interfaces;
using OrganizationService.Persistence.Entities;
using OrganizationService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure
{
    public class ReadOnlyOrganizationPersistenceAdapter : IReadOnlyOrganizationPersistenceAdapter
    {
        private readonly IReadOnlyOrganizationRepository _repository;

        public ReadOnlyOrganizationPersistenceAdapter(IReadOnlyOrganizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrganizationEntity>> GetAllOrganizations()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OrganizationEntity> GetOrganizationAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
