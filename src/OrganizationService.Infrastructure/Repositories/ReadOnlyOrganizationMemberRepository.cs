using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Repositories
{
    public class ReadOnlyOrganizationMemberRepository :  IReadOnlyOrganizationMemberRepository
    {
        private readonly OrganizationDbContext _context;
        private readonly IMapper<OrganizationMemberEntity, OrganizationMember> _mapper;
        private readonly IMapper<OrganizationEntity, Organization> _orgDomainMapper;

        public ReadOnlyOrganizationMemberRepository(
            OrganizationDbContext context, 
            IMapper<OrganizationMemberEntity, OrganizationMember> mapper,
            IMapper<OrganizationEntity, Organization> orgDomainMapper)
        {
            _context = context;
            _mapper = mapper;
            _orgDomainMapper = orgDomainMapper;
        }
        public async Task<IEnumerable<OrganizationMember>> GetAllMembers()
        {
            var list = await _context.OrganizationMembers.ToListAsync();
            return list.Select(x => _mapper.Map(x).ToOutFormat()).ToList();
        }

        public async Task<IEnumerable<Organization>> GetUserOrganizationsByEmail(string email)
        {
            List<OrganizationEntity> list =  await _context.OrganizationMembers
                .Include(x => x.Organization)
                .Where(x => x.Email == email)
                .Select(m => m.Organization)
                .ToListAsync();

            return list.Select(x => _orgDomainMapper.Map(x).ToOutFormat()).ToList();
        }
    }
}
