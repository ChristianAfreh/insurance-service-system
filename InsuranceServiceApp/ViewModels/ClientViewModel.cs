namespace InsuranceServiceApp.ViewModels
{
    public class ClientViewModel
    {
        public long ClientId { get; set; }
        public long ZoneId { get; set; }
        public string Surname { get; set; } = null!;
        public string Othername { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? Employer { get; set; }
        public int? ActiveFlag { get; set; }

    }

    public class ClientForManipulationViewModel
    {
        public long ZoneId { get; set; }
        public string Surname { get; set; } = null!;
        public string Othername { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? Employer { get; set; }
        public int? ActiveFlag { get; set; }


    }

    public class ClientForAddViewModel : ClientForManipulationViewModel
    {
        public DateTime DateCreated { get; set; }
        public long CreateAppUserId { get; set; }
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }
    }

    public class ClientForEditViewModel : ClientForManipulationViewModel
    {
        public DateTime? LastDateUpdated { get; set; }
        public long? LastUpdateAppUserId { get; set; }
    }

    public class ClientVehicleForAddEditViewModel
    {
        public ClientForAddViewModel? ClientForAddVm { get; set; }
        public VehicleForAddViewModel? VehicleForAddVm { get; set; }
    }
}
