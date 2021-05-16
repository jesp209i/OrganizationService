using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
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
        private readonly IMapper<Organization, OrganizationDto> _mapDomainToDto;
        private readonly IMapper<OrganizationMember, OrganizationMemberDto> _mapMemberDomainToDto;

        public OrganizationReadOnlyService(
            IReadOnlyOrganizationRepository organizationRepository, 
            IReadOnlyOrganizationMemberRepository memberRepository,
            IMapper<Organization, OrganizationDto> mapDomainToDto,
            IMapper<OrganizationMember, OrganizationMemberDto> mapMemberDomainToDto)
        {
            _organizationRepository = organizationRepository;
            _memberRepository = memberRepository;
            _mapDomainToDto = mapDomainToDto;
            _mapMemberDomainToDto = mapMemberDomainToDto;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var organizations = await _organizationRepository.GetAllAsync();

            return organizations.Select(x => _mapDomainToDto.Map(x).ToOutFormat()).ToList();
        }

        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            return _mapDomainToDto.Map(org).ToOutFormat();
        }

        public async Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid id)
        {
            var org = await _organizationRepository.GetAsync(id);

            var members = org.Members.Select(x => _mapMemberDomainToDto.Map(x).ToOutFormat()).ToList();
            
            return members;
        }

        public async Task<IEnumerable<OrganizationDto>> GetUserOrganizations(string email)
        {
            var orgs = await _memberRepository.GetUserOrganizationsByEmail(email);

            return orgs.Select(x => _mapDomainToDto.Map(x).ToOutFormat()
            ).ToList();
        }
    }
}
