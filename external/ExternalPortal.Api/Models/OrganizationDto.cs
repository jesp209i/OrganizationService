using Newtonsoft.Json;
using System;

namespace ExternalPortal.Api.Models
{
    public class OrganizationDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("streetExtended")]
        public string StreetExtended { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("changeDate")]
        public DateTime ChangeDate{ get; set; }
        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }
    }
}
