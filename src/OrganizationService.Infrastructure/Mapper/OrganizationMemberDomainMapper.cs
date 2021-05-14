using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;

namespace OrganizationService.Infrastructure.Mapper
{
    public class OrganizationMemberDomainMapper : AbstractMapper<OrganizationMemberEntity, OrganizationMember>, IMapper<OrganizationMemberEntity, OrganizationMember>
    {
        public override OrganizationMember ToOutFormat()
        {
            var orgId = new OrganizationId(_input.OrganizationId);
            var email = new Email(_input.Email);

            var orgMember = new OrganizationMember(
                orgId, email, _input.UserName, (Permission)_input.Permission);

            return orgMember;
        }
    }
}