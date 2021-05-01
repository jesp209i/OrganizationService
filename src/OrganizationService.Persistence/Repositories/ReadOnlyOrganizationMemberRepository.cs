using Microsoft.EntityFrameworkCore;
using OrganizationService.Persistence.Entities;
using OrganizationService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Persistence.Repositories
{
    public class ReadOnlyOrganizationMemberRepository : IReadOnlyOrganizationMemberRepository
    {
        private readonly OrganizationDbContext _context;

        public ReadOnlyOrganizationMemberRepository(OrganizationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrganizationMemberEntity>> GetAllMembers()
        {
            return await _context.OrganizationMembers.ToListAsync();
        }

        public async Task<IEnumerable<OrganizationMemberEntity>> GetUserOrganizationsByEmail(string email)
        {
            return await _context.OrganizationMembers.Include(x => x.Organization).Where(x => x.Email == email).ToListAsync();
        }
    }
}
