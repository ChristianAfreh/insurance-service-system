using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Status
    {
        public Status()
        {
            ServiceRequestStatuses = new HashSet<ServiceRequestStatus>();
        }

        public long StatusId { get; set; }
        public string Name { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<ServiceRequestStatus> ServiceRequestStatuses { get; set; }
    }
}
