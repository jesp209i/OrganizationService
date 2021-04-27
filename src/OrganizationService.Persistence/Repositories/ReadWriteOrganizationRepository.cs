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
    public class ReadWriteOrganizationRepository : RepositoryBase, IReadWriteOrganizationRepository
    {
        public ReadWriteOrganizationRepository(OrganizationDbContext context)
            : base(context) { }

        public async Task AddOrganization(OrganizationEntity organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
        }

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

        public async Task UpdateAsync(OrganizationEntity updatedOrganization)
        {
            var orgEntity = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == updatedOrganization.Id);
            if (orgEntity is null)
                throw new EntityNotFoundException($"Id: {updatedOrganization.Id} does not represent an OrganizationEntity");

            orgEntity = updatedOrganization;
            _context.Entry(orgEntity).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
        }
    }
}
