using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Client
    {
        public Client()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
            Vehicles = new HashSet<Vehicle>();
        }

        public long ClientId { get; set; }
        public long ZoneId { get; set; }
        public string Surname { get; set; } = null!;
        public string Othername { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? Employer { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Zone Zone { get; set; } = null!;
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
