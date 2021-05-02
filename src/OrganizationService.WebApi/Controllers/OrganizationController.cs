using Microsoft.AspNetCore.Mvc;
using OrganizationService.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrganizationService.WebApi.Viewmodels;
using System.Linq;

namespace OrganizationService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
{
        private readonly IOrganizationReadOnlyService _orgService;

        public OrganizationController(IOrganizationReadOnlyService orgService)
        {
            _orgService = orgService;
        }
        [HttpGet]
        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            var result = await _orgService.GetAll();
            
            return 
                result
                .Select(x => new Organization(x))
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<Organization> GetOrganization(Guid id)
        {
            var result = await _orgService.GetOrganization(id);

            return new Organization(result);
        }

        [HttpGet("{id}/members")]
        public async Task<IEnumerable<OrganizationMember>> GetOrganizationMembers(Guid id)
        {
            var result = await _orgService.GetOrganizationMembers(id);

            return
                result
                .Select(x => new OrganizationMember(x))
                .ToList();
        }
    }
}
