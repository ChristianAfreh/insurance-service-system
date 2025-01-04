namespace InsuranceServiceApp.Models
{
    public class GetClientVehicleList_Result
    {
        public long ClientID { get; set; }
        public string Surname { get; set; } = null!;
        public string Othername { get; set; } = null!;
        public string Cellphone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string RegistrationNo { get; set; } = null!;
        public string MakeModel { get; set; } = null!;
        public string Zone { get; set; } = null!;
        public int ActiveFlag { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
