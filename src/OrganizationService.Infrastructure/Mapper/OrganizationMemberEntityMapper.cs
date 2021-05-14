using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Entities;

namespace OrganizationService.Infrastructure.Mapper
{
    public class OrganizationMemberEntityMapper : AbstractMapper<OrganizationMember, OrganizationMemberEntity>, IMapper<OrganizationMember, OrganizationMemberEntity>
    {
        public override OrganizationMemberEntity ToOutFormat()
        {
            var orgMemberEntity = new OrganizationMemberEntity(
                _input.OrganizationId,_input.Email,_input.UserName, _input.Permission);
            
            return orgMemberEntity;
        }
    }
}
