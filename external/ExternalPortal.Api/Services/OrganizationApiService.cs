using ExternalPortal.Api.Models;
using Newtonsoft.Json;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExternalPortal.Api.Services
{
    public class OrganizationApiService
    {
        private readonly IBus _bus;

        private readonly HttpClient _client;
        private const string _base = "api/organization/";
        public OrganizationApiService(HttpClient client, IBus bus)
        {
            client.BaseAddress = new Uri("http://localhost:37038/");
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

        private async Task<T> GetAsync<T>(string requestUrl)
        {
            var request = await _client.GetAsync($"{_base}{requestUrl}");
            var responsetext = await request.Content.ReadAsStringAsync();
            T response = JsonConvert.DeserializeObject<T>(responsetext);
            return response;
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
    }
}
