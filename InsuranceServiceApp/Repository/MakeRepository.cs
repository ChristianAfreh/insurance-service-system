using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.Repository
{
    public class MakeRepository : BaseRepository<Make>, IMakeRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public MakeRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


    }
}
