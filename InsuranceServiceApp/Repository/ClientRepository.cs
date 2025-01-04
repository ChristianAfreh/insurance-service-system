using InsuranceServiceApp.Extensions;
using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InsuranceServiceApp.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public ClientRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


        public IEnumerable<GetClientVehicleList_Result> GetClientVehicleList()
        {
            var result = _insuranceDBContext.LoadStoredProc("usp_client_vehicle_list_get")
                            .ExecuteStoredProc<GetClientVehicleList_Result>().ToList();

            return result;
        }

    }
}
