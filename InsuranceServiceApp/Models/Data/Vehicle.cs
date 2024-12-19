using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Vehicle
    {
        public long VehicleId { get; set; }
        public long? ClientId { get; set; }
        public long ModelId { get; set; }
        public long? TypeId { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Colour { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Model Model { get; set; } = null!;
        public virtual VehicleType? Type { get; set; }
    }
}
