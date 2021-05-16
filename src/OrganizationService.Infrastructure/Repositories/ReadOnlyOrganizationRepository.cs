using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Domain;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Repositories
{
    public class ReadOnlyOrganizationRepository : RepositoryBase<OrganizationEntity>, IReadOnlyOrganizationRepository
    {
        private readonly IMapper<OrganizationEntity, Organization> _mapper;

        public ReadOnlyOrganizationRepository(OrganizationDbContext context, IMapper<OrganizationEntity, Organization> mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var list = await _context.Organizations.ToListAsync();
            return list.Select(x => _mapper.Map(x).ToOutFormat()).ToList();
        }

        public async Task<Organization> GetAsync(Guid id)
        {
            var entity = await _context.Organizations.Include(x=> x.Members).FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                throw new EntityNotFoundException($"Id: {id} does not represent an OrganizationEntity");

            return _mapper.Map(entity).ToOutFormat();
        }

    }
}
