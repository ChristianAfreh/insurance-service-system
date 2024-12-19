using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            Invoices = new HashSet<Invoice>();
            ServiceRequestStatuses = new HashSet<ServiceRequestStatus>();
        }

        public long RequestId { get; set; }
        public long ClientId { get; set; }
        public long? InsurerId { get; set; }
        public long RequestTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? Type { get; set; }
        public decimal? Amount { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Insurer? Insurer { get; set; }
        public virtual ServiceRequestType RequestType { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ServiceRequestStatus> ServiceRequestStatuses { get; set; }
    }
}
