using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public ClientRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


    }
}
