using Microsoft.EntityFrameworkCore;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using OrganizationService.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.Infrastructure.Repositories
{
    public class ReadWriteOrganizationRepository : RepositoryBase<OrganizationEntity>, IReadWriteOrganizationRepository
    {
        private readonly IMapper<Organization, OrganizationEntity> _mapper;
        private readonly IMapper<OrganizationEntity, Organization> _domainMapper;
        private readonly IMapper<OrganizationMember, OrganizationMemberEntity> _orgMemberEntityMapper;

        public ReadWriteOrganizationRepository(
            OrganizationDbContext context, 
            IMapper<Organization, OrganizationEntity> mapper,
            IMapper<OrganizationEntity, Organization> domainMapper,
            IMapper<OrganizationMember, OrganizationMemberEntity> orgMemberEntityMapper
            ) : base(context)
        {
            _mapper = mapper;
            _domainMapper = domainMapper;
            _orgMemberEntityMapper = orgMemberEntityMapper;
        }

        public async Task AddOrganization(Organization organization)
        {
            var orgEnt = _mapper.Map(organization).ToOutFormat();

            DbData.Add(orgEnt);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var list = await _context.Organizations.ToListAsync();

            return list.Select(x => _domainMapper.Map(x).ToOutFormat()).ToList();
        }

        public async Task<Organization> GetAsync(Guid id)
        {
            var entity = await _context.Organizations.Include(x=> x.Members).FirstOrDefaultAsync(x => x.Id == id);
            
            if (entity is null)
                throw new EntityNotFoundException($"Id: {id} does not represent an OrganizationEntity");
            
            return _domainMapper.Map(entity).ToOutFormat();
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
            orgEntity.Members = updatedOrganization.Members.Select(x => _orgMemberEntityMapper.Map(x).ToOutFormat()).ToList();

            _context.Entry(orgEntity).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
        }
    }
}
