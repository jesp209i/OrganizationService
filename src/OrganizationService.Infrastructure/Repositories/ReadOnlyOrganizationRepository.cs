using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Domain;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Exceptions;
using OrganizationService.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Repositories
{
    public class ReadOnlyOrganizationRepository : RepositoryBase<OrganizationEntity>, IReadOnlyOrganizationRepository
    {
        public ReadOnlyOrganizationRepository(OrganizationDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var list = await _context.Organizations.ToListAsync();
            return list.Select(x => PersistenceMapper.Map(x).ToDomain()).ToList();
        }

        public async Task<Organization> GetAsync(Guid id)
        {
            var entity = await _context.Organizations.Include(x=> x.Members).FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                throw new EntityNotFoundException($"Id: {id} does not represent an OrganizationEntity");

            return PersistenceMapper.Map(entity).ToDomain();
        }

    }
}
