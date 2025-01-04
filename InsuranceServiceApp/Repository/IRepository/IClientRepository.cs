using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using System.Diagnostics;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        IEnumerable<GetClientVehicleList_Result> GetClientVehicleList();
    }
}
