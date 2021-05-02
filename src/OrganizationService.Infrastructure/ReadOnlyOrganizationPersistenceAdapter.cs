using OrganizationService.Infrastructure.Interfaces;
using OrganizationService.Persistence.Entities;
using OrganizationService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure
{
    public class ReadOnlyOrganizationPersistenceAdapter : IReadOnlyOrganizationPersistenceAdapter
    {
        private readonly IReadOnlyOrganizationRepository _repository;
        private readonly IReadOnlyOrganizationMemberRepository _memberRepository;

        public ReadOnlyOrganizationPersistenceAdapter(IReadOnlyOrganizationRepository repository, IReadOnlyOrganizationMemberRepository memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<OrganizationEntity>> GetAllOrganizations()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OrganizationEntity> GetOrganizationAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<OrganizationMemberEntity>> GetUserOrganizationsByEmail(string email)
        {
            return  await _memberRepository.GetUserOrganizationsByEmail(email);
        }
    }
}
