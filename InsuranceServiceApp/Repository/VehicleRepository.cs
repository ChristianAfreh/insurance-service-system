using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;

        public VehicleRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


    }
}
