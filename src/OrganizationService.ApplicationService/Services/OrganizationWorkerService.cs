using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain.Enum;
using OrganizationService.Domain.ValueObjects;
using OrganizationService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Services
{
    public class OrganizationWorkerService : OrganizationServiceBase, IOrganizationWorkerService
    {
        private IOrganizationPersistenceAdapter Persistence { get => _persistence as IOrganizationPersistenceAdapter; }
        public OrganizationWorkerService(IOrganizationPersistenceAdapter persistence)
            : base(persistence) { }

        public async Task AddOrganization(OrganizationDto model)
        {
            var org = DtoMapper.Map(model).ToDomain();
            await Persistence.AddOrganization(org);
        }

        public async Task UpdateOrganization(OrganizationDto model)
        {
            var organization = DtoMapper.Map(model).ToDomain();
            await Persistence.UpdateOrganizationAsync(organization);
        }

        public async Task ChangeOrganizationWebsite(ChangeOrganizationWebsiteDto changeModel)
        {
            var organization = await Persistence.GetOrganizationAsync(changeModel.Id);
            organization.ChangeWebsite(changeModel.Website, changeModel.ChangeDate, changeModel.ChangedBy);
            
            await Persistence.UpdateOrganizationAsync(organization);
        }

        public async Task ChangeOrganizationAddress(ChangeOrganizationAddressDto changeModel)
        {
            var address = new Address(changeModel.Street, changeModel.StreetExtended, changeModel.PostalCode, changeModel.City, changeModel.Country);
            
            var organization = await Persistence.GetOrganizationAsync(changeModel.Id);
            organization.ChangeAddress(address, changeModel.ChangeDate, changeModel.ChangedBy);

            await Persistence.UpdateOrganizationAsync(organization);
        }

        public async Task ChangeOrganizationVatNumber(ChangeOrganizationVatNumberDto changeModel)
        {
            var vatNumber = new VatNumber(changeModel.VatNumber);

            var organization = await Persistence.GetOrganizationAsync(changeModel.Id);
            organization.ChangeVatNumber(vatNumber, changeModel.ChangeDate, changeModel.ChangedBy);

            await Persistence.UpdateOrganizationAsync(organization);
        }

        public async Task AddOrganizationMember(OrganizationMemberDto newMember)
        {
            var organization = await Persistence.GetOrganizationAsync(newMember.OrganizationId);

            organization.AddMember(newMember.Email,newMember.UserName, newMember.Permission, newMember.ChangeDate, newMember.ChangedBy);

            await Persistence.UpdateOrganizationAsync(organization);
        }

        public async Task ChangeOrganizationMemberPermission(ChangeOrganizationMemberPermissionDto changePermission)
        {
            var organization = await Persistence.GetOrganizationAsync(changePermission.OrganizationId);

            organization.UpdateMemberPermission(changePermission.Email, changePermission.Permission, changePermission.ChangeDate, changePermission.ChangedBy);

            await Persistence.UpdateOrganizationAsync(organization);
        }
    }
}
