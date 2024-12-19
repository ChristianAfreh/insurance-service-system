using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class ServiceRequestStatus
    {
        public long ServiceRequestStatusId { get; set; }
        public long RequestId { get; set; }
        public long StatusId { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ServiceRequest Request { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
