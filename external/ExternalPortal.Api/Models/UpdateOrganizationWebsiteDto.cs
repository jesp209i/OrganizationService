using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
