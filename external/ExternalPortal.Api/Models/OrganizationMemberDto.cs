using Newtonsoft.Json;

namespace ExternalPortal.Api.Models
{
    public class OrganizationMemberDto
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("permission")]
        public int Permission { get; set; }
    }
}
