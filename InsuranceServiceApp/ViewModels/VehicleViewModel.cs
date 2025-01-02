namespace InsuranceServiceApp.ViewModels
{
    public class VehicleViewModel
    {
        public long VehicleId { get; set; }
        public long? ClientId { get; set; }
        public long ModelId { get; set; }
        public long? TypeId { get; set; }
        public string? RegistrationNo { get; set; }
        public string? ColourCode { get; set; }
        public int? ActiveFlag { get; set; }
    }

    public class VehicleForManipulationViewModel
    {
        public long VehicleId { get; set; }
        public long? ClientId { get; set; }
        public long ModelId { get; set; }
        public long? TypeId { get; set; }
        public string? RegistrationNo { get; set; }
        public string? ColourCode { get; set; }
        public int? ActiveFlag { get; set; }
    }

    public class VehicleForAddViewModel : VehicleForManipulationViewModel
    {
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }
    }
}
