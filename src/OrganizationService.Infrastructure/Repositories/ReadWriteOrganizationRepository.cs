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
    public class ReadWriteOrganizationRepository : RepositoryBase<OrganizationEntity>, IReadWriteOrganizationRepository
    {
        public ReadWriteOrganizationRepository(OrganizationDbContext context)
            : base(context) { }

        public async Task AddOrganization(Organization organization)
        {
            var orgEnt = PersistenceMapper.Map(organization).ToEntity();

            DbData.Add(orgEnt);
            await _context.SaveChangesAsync();
        }

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

        public async Task UpdateAsync(Organization updatedOrganization)
        {
            var orgEntity = await _context.Organizations.Include(x=> x.Members).FirstOrDefaultAsync(x => x.Id == updatedOrganization.Id);
            if (orgEntity is null)
                throw new EntityNotFoundException($"Id: {updatedOrganization.Id} does not represent an OrganizationEntity");

            orgEntity.Name = updatedOrganization.Name;
            orgEntity.Street = updatedOrganization.Address.Street;
            orgEntity.StreetExtended = updatedOrganization.Address.StreetExtended;
            orgEntity.PostalCode = updatedOrganization.Address.PostalCode;
            orgEntity.City = updatedOrganization.Address.City;
            orgEntity.Country = updatedOrganization.Address.Country;
            orgEntity.VatNumber = updatedOrganization.VatNumber;
            orgEntity.Website = updatedOrganization.Website;
            orgEntity.ChangeDate = updatedOrganization.ChangeDate;
            orgEntity.ChangedBy = updatedOrganization.ChangedBy;
            orgEntity.Members = updatedOrganization.Members.Select(x => PersistenceMapper.Map(updatedOrganization).MemberToEntity(x)).ToList();

            _context.Entry(orgEntity).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
        }
    }
}
