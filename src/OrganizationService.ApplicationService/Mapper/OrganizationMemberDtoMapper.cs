using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.ValueObjects;

namespace OrganizationService.ApplicationService.Mapper
{
    public class OrganizationMemberDtoMapper : AbstractMapper<OrganizationMember, OrganizationMemberDto>, IMapper<OrganizationMember, OrganizationMemberDto>
    {
        public override OrganizationMemberDto ToOutFormat()
        {
            var orgMemberDto = new OrganizationMemberDto
            {
                OrganizationId = _input.OrganizationId,
                Email = _input.Email,
                UserName = _input.UserName,
                Permission = _input.Permission
            };

            return orgMemberDto;
        }
    }
}
