using ExternalPortal.Api.Filters;
using ExternalPortal.Api.Models;
using ExternalPortal.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExternalPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationApiService _organizationApiService;

        public OrganizationController(OrganizationApiService organizationApiService)
        {
            _organizationApiService = organizationApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganizations() 
            => Ok(await _organizationApiService.GetAll());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization([GuidModelValidator] string id)
        {
            var validId = Guid.Parse(id);
            var response = await _organizationApiService.Get(validId);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task CreateOrganization(OrganizationDto newOrganization)
        {
            await _organizationApiService.CreateOrganization(newOrganization);
        }
    }
}
