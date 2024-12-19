using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Region
    {
        public Region()
        {
            Zones = new HashSet<Zone>();
        }

        public long RegionId { get; set; }
        public long CountryId { get; set; }
        public string Name { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
