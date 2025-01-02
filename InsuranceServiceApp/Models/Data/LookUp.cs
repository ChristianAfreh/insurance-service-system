using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class LookUp
    {
        public long LookUpId { get; set; }
        public string FullName { get; set; } = null!;
        public string? ShortName { get; set; }
        public bool? UseShortName { get; set; }
        public long LookUpCodeId { get; set; }
        public int? ActiveFlag { get; set; }
        public bool? Toggled { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual LookUpCode LookUpCode { get; set; } = null!;
    }
}
