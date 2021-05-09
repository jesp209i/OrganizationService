using ExternalPortal.Api.Models;
using Newtonsoft.Json;
using OrganizationService.Shared.Messages.Commands.Organization;
using OrganizationService.Shared.Messages.Commands.OrganizationMember;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ExternalPortal.Api.Services
{
    public class OrganizationApiService
    {
        private readonly IBus _bus;

        private readonly HttpClient _client;
        private const string _base = "api/organization/";
        public OrganizationApiService(HttpClient client, IBus bus)
        {
            client.BaseAddress = new Uri("https://acmeorganizationworker.azurewebsites.net/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _bus = bus;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var response = await GetAsync<IEnumerable<OrganizationDto>>("");
            return response;
        }

        public async Task<OrganizationDto> Get(Guid id)
        {
            var response = await GetAsync<OrganizationDto>(id.ToString());
            return response;
        }
        public async Task<IEnumerable<OrganizationDto>> GetByEmail(SearchByEmail search)
        {
            var userUrl = $"api/user/{HttpUtility.UrlEncode(search.Email)}";
            var request = await _client.GetAsync(userUrl);
            var responsetext = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<List<OrganizationDto>>(responsetext);
            return response;
        }

        private async Task<T> GetAsync<T>(string requestUrl)
        {
            var request = await _client.GetAsync($"{_base}{requestUrl}");
            var responsetext = await request.Content.ReadAsStringAsync();
            T response = JsonConvert.DeserializeObject<T>(responsetext);
            return response;
        }

        public async Task<IEnumerable<OrganizationMemberDto>> GetOrganizationMembers(Guid organizationId)
        {
            var response = await GetAsync<List<OrganizationMemberDto>>($"{organizationId}/members");
            return response;
        }

        public async Task AddOrganizationMember(AddOrganizationMemberDto addMember)
        {
            var command = new AddOrganizationMemberCommand(
                addMember.OrganizationId,
                addMember.UserName,
                addMember.Email,
                addMember.Permission,
                addMember.ChangeDate,
                addMember.ChangedBy
                );
            await _bus.Send(command);
        }

        public async Task UpdateOrganizationMemberPermission(ChangeOrganizationMemberPermissionDto changePermission)
        {
            var command = new ChangeOrganizationMemberPermissionCommand(
                changePermission.OrganizationId,
                changePermission.Email,
                changePermission.Permission,
                changePermission.ChangeDate,
                changePermission.ChangedBy
                );
            await _bus.Send(command);
        }

        public async Task CreateOrganization(OrganizationDto newOrganization)
        {
            var id = Guid.NewGuid();
            var command = new CreateOrganizationCommand(
                id,
                newOrganization.Name,
                newOrganization.Street,
                newOrganization.StreetExtended,
                newOrganization.PostalCode,
                newOrganization.City,
                newOrganization.Country,
                newOrganization.VatNumber,
                newOrganization.Website,
                newOrganization.ChangeDate,
                newOrganization.ChangedBy);
            await _bus.Send(command);
        }

        public async Task UpdateAddress(string id, UpdateOrganizationAddressDto updateAddress)
        {
            var command = new ChangeOrganizationAddressCommand(
                new Guid(id),
                updateAddress.Street,
                updateAddress.StreetExtended,
                updateAddress.PostalCode,
                updateAddress.City,
                updateAddress.Country,
                updateAddress.ChangeDate,
                updateAddress.ChangedBy
                );
            await _bus.Send(command);
        }

        public async Task UpdateVatNumber(string id, UpdateOrganizationVatNumberDto updateVatNumber)
        {
            var command = new ChangeOrganizationVatNumberCommand(
                new Guid(id),
                updateVatNumber.VatNumber,
                updateVatNumber.ChangeDate,
                updateVatNumber.ChangedBy
                );
            await _bus.Send(command);
        }

        public async Task UpdateWebsite(string id, UpdateOrganizationWebsiteDto updateWebsite)
        {
            var command = new ChangeOrganizationWebsiteCommand(
                new Guid(id),
                updateWebsite.Website,
                updateWebsite.ChangeDate,
                updateWebsite.ChangedBy
                );
            await _bus.Send(command);
        }
    }
}
