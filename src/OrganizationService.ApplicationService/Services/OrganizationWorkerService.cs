using OrganizationService.ApplicationService.Interfaces;
using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Interfaces.Repository;
using OrganizationService.ApplicationService.Models;
using OrganizationService.ApplicationService.Models.OrganizationMember;
using OrganizationService.Domain;
using OrganizationService.Domain.ValueObjects;
using System.Threading.Tasks;

namespace OrganizationService.ApplicationService.Services
{
    public class OrganizationWorkerService : IOrganizationWorkerService
    {
        private readonly IReadWriteOrganizationRepository _organizationRepository;
        private readonly IMapper<OrganizationDto,Organization> _mapper;

        public OrganizationWorkerService(IReadWriteOrganizationRepository organizationRepository, IMapper<OrganizationDto, Organization> mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task AddOrganization(OrganizationDto model)
        {
            var org = _mapper.Map(model).ToOutFormat();
            await _organizationRepository.AddOrganization(org);
        }

        public async Task UpdateOrganization(OrganizationDto model)
        {
            var organization = _mapper.Map(model).ToOutFormat();
            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task ChangeOrganizationWebsite(ChangeOrganizationWebsiteDto changeModel)
        {
            var organization = await _organizationRepository.GetAsync(changeModel.Id);

            organization.ChangeWebsite(changeModel.Website, changeModel.ChangeDate, changeModel.ChangedBy);
            
            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task ChangeOrganizationAddress(ChangeOrganizationAddressDto changeModel)
        {
            var address = new Address(changeModel.Street, changeModel.StreetExtended, changeModel.PostalCode, changeModel.City, changeModel.Country);
            
            var organization = await _organizationRepository.GetAsync(changeModel.Id);
            organization.ChangeAddress(address, changeModel.ChangeDate, changeModel.ChangedBy);

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task ChangeOrganizationVatNumber(ChangeOrganizationVatNumberDto changeModel)
        {
            var vatNumber = new VatNumber(changeModel.VatNumber);

            var organization = await _organizationRepository.GetAsync(changeModel.Id);
            organization.ChangeVatNumber(vatNumber, changeModel.ChangeDate, changeModel.ChangedBy);

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task AddOrganizationMember(OrganizationMemberDto newMember)
        {
            var organization = await _organizationRepository.GetAsync(newMember.OrganizationId);

            organization.AddMember(newMember.Email,newMember.UserName, newMember.Permission, newMember.ChangeDate, newMember.ChangedBy);

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task ChangeOrganizationMemberPermission(ChangeOrganizationMemberPermissionDto changePermission)
        {
            var organization = await _organizationRepository.GetAsync(changePermission.OrganizationId);

            organization.UpdateMemberPermission(changePermission.Email, changePermission.Permission, changePermission.ChangeDate, changePermission.ChangedBy);

            await _organizationRepository.UpdateAsync(organization);
        }
    }
}
