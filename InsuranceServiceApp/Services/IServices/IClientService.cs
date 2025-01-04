using InsuranceServiceApp.Models;
using InsuranceServiceApp.ViewModels;

namespace InsuranceServiceApp.Services.IServices
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetAllClients();
        IEnumerable<GetClientVehicleList_Result> GetClientVehicleListForGridDisplay();
        ClientViewModel GetClientByClientId(long clientId);
        void AddClientVehicleData(ClientVehicleForAddEditViewModel clientVehicleAddModel);
        ClientVehicleForAddSelectListViewModel GetSelectListsForClientVehicleAdd();
    }
}
