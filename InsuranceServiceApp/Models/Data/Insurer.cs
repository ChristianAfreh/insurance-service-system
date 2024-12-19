using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Insurer
    {
        public Insurer()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public long InsurerId { get; set; }
        public long InsurerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual InsurerType InsurerType { get; set; } = null!;
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
