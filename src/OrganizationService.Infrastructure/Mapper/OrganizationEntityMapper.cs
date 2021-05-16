using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationService.Infrastructure.Mapper
{
    public class OrganizationEntityMapper : AbstractMapper<Organization, OrganizationEntity>, IMapper<Organization, OrganizationEntity>
    {
        private readonly IMapper<OrganizationMember, OrganizationMemberEntity> _memberMapper;

        public OrganizationEntityMapper(IMapper<OrganizationMember, OrganizationMemberEntity> memberMapper)
        {
            _memberMapper = memberMapper;
        }

        public override OrganizationEntity ToOutFormat()
        {
            var members = MapMembers(_input.Members);
            
            OrganizationEntity orgEntity = new OrganizationEntity {
                Id = _input.Id,
                Name = _input.Name,
                Street = _input.Address.Street,
                StreetExtended = _input.Address.StreetExtended,
                PostalCode = _input.Address.PostalCode,
                City = _input.Address.City,
                Country = _input.Address.Country,
                VatNumber = _input.VatNumber,
                Website = _input.Website,
                Members = members,
                ChangeDate = _input.ChangeDate, 
                ChangedBy = _input.ChangedBy
                };

            return orgEntity;
        }

        private List<OrganizationMemberEntity> MapMembers(IList<OrganizationMember> members)
        {
            if (members.Count == 0)
                return new List<OrganizationMemberEntity>();

            return members.Select(x => _memberMapper.Map(x).ToOutFormat()).ToList();
        }
    }
}