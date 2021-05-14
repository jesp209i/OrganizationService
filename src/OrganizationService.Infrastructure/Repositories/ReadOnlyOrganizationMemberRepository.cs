using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Domain;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Repositories
{
    public class ReadOnlyOrganizationMemberRepository :  IReadOnlyOrganizationMemberRepository
    {
        private readonly OrganizationDbContext _context;

        public ReadOnlyOrganizationMemberRepository(OrganizationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrganizationMember>> GetAllMembers()
        {
            var list = await _context.OrganizationMembers.ToListAsync();
            return CreateMemberList(list);
        }

        public async Task<IEnumerable<Organization>> GetUserOrganizationsByEmail(string email)
        {
            List<OrganizationEntity> list =  await _context.OrganizationMembers
                .Include(x => x.Organization)
                .Where(x => x.Email == email)
                .Select(m => m.Organization)
                .ToListAsync();

            return list.Select(x => PersistenceMapper.Map(x).ToDomain()).ToList();
        }

        private IEnumerable<OrganizationMember> CreateMemberList(IEnumerable<OrganizationMemberEntity> list)
            => list.Select(x => BuildMember(x)).ToList();

        private OrganizationMember BuildMember(OrganizationMemberEntity entity)
            => new OrganizationMember(new OrganizationId(entity.OrganizationId), new Email(entity.Email), entity.UserName, (Permission)entity.Permission);
        
    }
}
