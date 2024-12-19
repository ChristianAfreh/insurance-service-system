using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
        }

        public long MakeId { get; set; }
        public string Name { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
