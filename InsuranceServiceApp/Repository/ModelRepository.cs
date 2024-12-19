using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.Repository
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public ModelRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


    }
}
