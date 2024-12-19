using System;
using System.Collections.Generic;

namespace InsuranceServiceApp.Models.Data
{
    public partial class Invoice
    {
        public long InvoiceId { get; set; }
        public long RequestId { get; set; }
        public string? InvoiceNo { get; set; }
        public string ClientName { get; set; } = null!;
        public string? ClientAddress { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientCellphone { get; set; }
        public string? InsurerName { get; set; }
        public string? InsurerAddress { get; set; }
        public int? ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }

        public virtual ServiceRequest Request { get; set; } = null!;
    }
}
