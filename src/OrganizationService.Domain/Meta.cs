using System;

namespace OrganizationService.Domain
{
    public abstract class Meta
    {
        public string ChangedBy { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}