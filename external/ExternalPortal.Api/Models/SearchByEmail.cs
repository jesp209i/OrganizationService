using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ExternalPortal.Api.Models
{
    public class SearchByEmail
    {
        [JsonProperty("email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
