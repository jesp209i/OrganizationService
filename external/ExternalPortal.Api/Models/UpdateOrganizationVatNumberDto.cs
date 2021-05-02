using Newtonsoft.Json;
using System;

namespace ExternalPortal.Api.Models
{
    public class UpdateOrganizationVatNumberDto
    {
        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }
        [JsonProperty("changeDate")]
        public DateTime ChangeDate{ get; set; }
        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }
    }
}
