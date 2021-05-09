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

        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetOrganizationMembers([GuidModelValidator] string id)
        {
            var validId = Guid.Parse(id);
            var response = await _organizationApiService.GetOrganizationMembers(validId);
            if (response == null)
                return NotFound();
            
            return Ok(response);
        }

        [HttpPost("{id}/members")]
        public async Task CreateOrganizationMember(AddOrganizationMemberDto addMember)
        {
            await _organizationApiService.AddOrganizationMember(addMember);
        }

        [HttpPut("{id}/members/{email}")]
        public async Task UpdateOrganizationMemberPermission(ChangeOrganizationMemberPermissionDto change)
        {
            await _organizationApiService.UpdateOrganizationMemberPermission(change);
        }

        [HttpPost]
        public async Task CreateOrganization(OrganizationDto newOrganization)
        {
            await _organizationApiService.CreateOrganization(newOrganization);
        }
        
        [HttpPut("{id}/website")]
        public async Task UpdateOrganizationWebsite([GuidModelValidator] string id, UpdateOrganizationWebsiteDto updateWebsite)
        {
            await _organizationApiService.UpdateWebsite(id, updateWebsite);
        }

        [HttpPut("{id}/address")]
        public async Task UpdateOrganizationAddress([GuidModelValidator] string id, UpdateOrganizationAddressDto updateAddress)
        {
            await _organizationApiService.UpdateAddress(id, updateAddress);
        }

        [HttpPut("{id}/vatnumber")]
        public async Task UpdateOrganizationVatNumber([GuidModelValidator] string id, UpdateOrganizationVatNumberDto updateName)
        {
            await _organizationApiService.UpdateVatNumber(id, updateName);
        }

        [HttpPost("search")]
        public async Task<IActionResult> FindOrganizationsByEmail(SearchByEmail search) =>
            Ok(await _organizationApiService.GetByEmail(search));
    }
}
