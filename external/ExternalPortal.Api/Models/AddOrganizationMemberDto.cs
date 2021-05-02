using Newtonsoft.Json;
using System;

namespace ExternalPortal.Api.Models
{
    public class AddOrganizationMemberDto
    {
        [JsonProperty("organizationId")]
        public Guid OrganizationId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("permission")]
        public int Permission { get; set; }
        [JsonProperty("changeDate")]
        public DateTime ChangeDate { get; set; }
        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }
    }
}
