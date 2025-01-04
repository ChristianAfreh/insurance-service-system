using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Surname is a required field")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Othername(s) is a required field")]
        public string Othername { get; set; } = null!;

        [Required(ErrorMessage = "Phonenumber is a required field")]
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


    public class ClientVehicleForAddSelectListViewModel
    {
        public SelectList ZoneSelectList { get; set; } 
        public SelectList MakeSelectList { get; set; }
        public SelectList ModeSelectList { get; set; }
        public SelectList ColourSelectList { get; set; }
        public SelectList VehicleTypeSelectList { get; set; }
    } 
    
    public class ClientVehicleModelForGridDisplay
    {
        public long ClientId { get; set; }
        public string Surname { get; set; } = null!;
        public string Othername { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public string MakeName { get;set; } = null!;
        public string ModelName { get; set; } = null!;
        public string RegistrationNo { get; set; } = null!;
    }
}
