using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationService.Infrastructure.Mapper
{
    public class OrganizationDomainMapper : AbstractMapper<OrganizationEntity, Organization>, IMapper<OrganizationEntity, Organization>
    {
        private readonly IMapper<OrganizationMemberEntity, OrganizationMember> _memberMapper;

        public OrganizationDomainMapper(IMapper<OrganizationMemberEntity, OrganizationMember> memberMapper)
        {
            _memberMapper = memberMapper;
        }

        public override Organization ToOutFormat()
        {
            var id = new OrganizationId(_input.Id);
            var name = new OrganizationName(_input.Name);
            var address = new Address(
                _input.Street,
                _input.StreetExtended,
                _input.PostalCode,
                _input.City,
                _input.Country
                );
            var vatNumber = new VatNumber(_input.VatNumber);
            var website = _input.Website;
            var members = MapMembers(_input.Members);
            Organization org = new Organization(
                id,name, address, vatNumber, website, members, _input.ChangeDate, _input.ChangedBy
                );

            return org;
        }

        private List<OrganizationMember> MapMembers(IList<OrganizationMemberEntity> members)
        {
            if (members.Count == 0)
                return new List<OrganizationMember>();

            return members.Select(x => _memberMapper.Map(x).ToOutFormat()).ToList();
        }
    }
}
