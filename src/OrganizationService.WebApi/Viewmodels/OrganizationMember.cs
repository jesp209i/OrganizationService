using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.WebApi.Viewmodels
{
    public class OrganizationMember
    {
        public OrganizationMember(OrganizationMemberDto member)
        {
            UserName = member.UserName;
            Email = member.Email;
            Permission = member.Permission;
        }

        public string UserName { get; set; }   
        public string Email { get; set; }
        public Permission Permission { get; set; }
    }
}
