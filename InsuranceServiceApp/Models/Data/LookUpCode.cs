using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class LookUpCode
    {
        public LookUpCode()
        {
            LookUps = new HashSet<LookUp>();
        }

        public long LookUpCodeId { get; set; }
        public string? LookUpShortCode { get; set; }
        public string LookUpName { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<LookUp> LookUps { get; set; }
    }
}
