﻿using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public long ModelId { get; set; }
        public long MakeId { get; set; }
        public string Name { get; set; } = null!;
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual Make Make { get; set; } = null!;
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}