using OrganizationService.ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Interfaces
{
    public interface IOrganizationWorkerService
    {
        Task AddOrganization(OrganizationDto organization);
        //Task ChangeOrganizationAddress();
        Task UpdateOrganization(OrganizationDto organization);
    }
}
