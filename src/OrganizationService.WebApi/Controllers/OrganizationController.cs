using Microsoft.AspNetCore.Mvc;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrganizationService.ApplicationService.Services;

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
        public async Task<IEnumerable<OrganizationDto>> GetOrganizations()
        {
            return await _orgService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<OrganizationDto> GetOrganization(Guid id)
        {
            return await _orgService.GetOrganization(id);
        }
    }
}
