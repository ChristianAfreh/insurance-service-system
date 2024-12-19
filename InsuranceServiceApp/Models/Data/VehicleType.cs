using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public long TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
