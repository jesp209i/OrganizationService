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
        private readonly DtoMapper _mapper;

        public OrganizationReadOnlyService(IReadOnlyOrganizationRepository organizationRepository, IReadOnlyOrganizationMemberRepository memberRepository, DtoMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var organizations = await _organizationRepository.GetAllAsync();

            return organizations.Select(x => _mapper.Map(x).ToDto()).ToList();
        }

        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            return _mapper.Map(org).ToDto();
        }

        public async Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            var members = _mapper.Map(org).ToOrganizationMembersDto();
            
            return members;
        }

        public async Task<IEnumerable<OrganizationDto>> GetUserOrganizations(string email)
        {
            var orgs = await _memberRepository.GetUserOrganizationsByEmail(email);

            return orgs.Select(x => _mapper.Map(x).ToDto()
            ).ToList();
        }
    }
}
