using Microsoft.EntityFrameworkCore;
using OrganizationService.Persistence.Entities;
using OrganizationService.Persistence.Exceptions;
using OrganizationService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationService.Persistence.Repositories
{
    public class ReadOnlyOrganizationRepository : RepositoryBase, IReadOnlyOrganizationRepository
    {
        public ReadOnlyOrganizationRepository(OrganizationDbContext context)
            : base(context) { }

        public async Task<IEnumerable<OrganizationEntity>> GetAllAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<OrganizationEntity> GetAsync(Guid id)
        {
            var entity = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                throw new EntityNotFoundException($"Id: {id} does not represent an OrganizationEntity");

            return entity;
        }
    }
}
