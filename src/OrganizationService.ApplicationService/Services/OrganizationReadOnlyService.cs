using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Services
{
    public class OrganizationReadOnlyService : IOrganizationReadOnlyService
    {
        private readonly IReadOnlyOrganizationRepository _organizationRepository;
        private readonly IReadOnlyOrganizationMemberRepository _memberRepository;

        
        public OrganizationReadOnlyService(IReadOnlyOrganizationRepository organizationRepository, IReadOnlyOrganizationMemberRepository memberRepository)
        {
            _organizationRepository = organizationRepository;
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var organizations = await _organizationRepository.GetAllAsync();

            return organizations.Select(x => DtoMapper.Map(x).ToDto()).ToList();
        }

        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            return DtoMapper.Map(org).ToDto();
        }

        public async Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            var members = DtoMapper.Map(org).ToOrganizationMembersDto();
            
            return members;
        }

        public async Task<IEnumerable<OrganizationDto>> GetUserOrganizations(string email)
        {
            var orgs = await _memberRepository.GetUserOrganizationsByEmail(email);

            return orgs.Select(x => DtoMapper.Map(x).ToDto()
            ).ToList();
        }
    }
}
