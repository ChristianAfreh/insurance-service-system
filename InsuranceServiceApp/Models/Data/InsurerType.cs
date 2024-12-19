using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class InsurerType
    {
        public InsurerType()
        {
            Insurers = new HashSet<Insurer>();
        }

        public long InsurerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<Insurer> Insurers { get; set; }
    }
}
