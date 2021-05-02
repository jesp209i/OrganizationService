using OrganizationService.ApplicationService.Models.OrganizationMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.WebApi.Viewmodels
{
    public class OrganizationUserPermission
    {
        public OrganizationUserPermission(OrganizationUserPermissionDto x)
        {
            OrganizationId = x.OrganizationId;
            OrganizationName = x.OrganizationName;
            Permission = x.Permission.ToString();
        }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Permission { get; set; }
    }
}
