using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Zone
    {
        public Zone()
        {
            Clients = new HashSet<Client>();
        }

        public long ZoneId { get; set; }
        public long RegionId { get; set; }
        public string Name { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; }
    }
}
