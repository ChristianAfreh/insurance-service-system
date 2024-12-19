using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class ServiceRequestType
    {
        public ServiceRequestType()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public long RequestTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
