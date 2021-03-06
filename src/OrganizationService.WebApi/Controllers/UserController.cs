using Microsoft.AspNetCore.Mvc;
using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.WebApi.Viewmodels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOrganizationReadOnlyService _service;

        public UserController(IOrganizationReadOnlyService service)
        {
            _service = service;
        }

        [HttpGet("{email}")]
        public async Task<IEnumerable<Organization>> GetUserOrganizations(string email)
        {
            var result = await _service.GetUserOrganizations(email);
            return result.Select(x => new Organization(x)).ToList();
        }
    }
}
