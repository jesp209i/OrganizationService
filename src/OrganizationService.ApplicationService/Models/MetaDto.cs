using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizationService.ApplicationService.Models
{
    public abstract class MetaDto
    {
        [Required]
        public DateTime ChangeDate { get; set; }
        [Required]
        public string ChangedBy { get; set; }
    }
}
