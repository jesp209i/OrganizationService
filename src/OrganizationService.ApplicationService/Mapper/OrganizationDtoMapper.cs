using OrganizationService.ApplicationService.Interfaces.Mapper;
using OrganizationService.ApplicationService.Models;
using OrganizationService.Domain;

namespace OrganizationService.ApplicationService.Mapper
{
    public class OrganizationDtoMapper : AbstractMapper<Organization, OrganizationDto>, IMapper<Organization, OrganizationDto>
    {
        public override OrganizationDto ToOutFormat()
        {
            var organizationDto = new OrganizationDto
            {
                Id = _input.Id,
                Name = _input.Name,
                Street = _input.Address.Street,
                StreetExtended = _input.Address.StreetExtended,
                PostalCode = _input.Address.PostalCode,
                City = _input.Address.City,
                Country = _input.Address.Country,
                VatNumber = _input.VatNumber,
                Website = _input.Website,
                ChangedBy = _input.ChangedBy,
                ChangeDate = _input.ChangeDate
            };

            return organizationDto;
        }
    }
}
