using Newtonsoft.Json;
using System;

namespace ExternalPortal.Api.Models
{
    public class UpdateOrganizationWebsiteDto
    {
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("changeDate")]
        public DateTime ChangeDate { get; set; }
        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }
    }
}
