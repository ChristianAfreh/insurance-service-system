using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public long CountryId { get; set; }
        public string Name { get; set; } = null!;
        public string? CountryCode { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
