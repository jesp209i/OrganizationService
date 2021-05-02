using System;

namespace OrganizationService.Domain
{
    public abstract class Meta
    {
        public string ChangedBy { get; protected set; }
        public DateTime ChangeDate { get; protected set; }

        protected void UpdateMeta(DateTime changeDate, string changedBy)
        {
            ChangeDate = changeDate;
            ChangedBy = changedBy;
        }
    }
}