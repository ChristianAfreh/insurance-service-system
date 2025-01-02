using InsuranceServiceApp.ViewModels;

namespace InsuranceServiceApp.Services.IServices
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetAllClients();
        ClientViewModel GetClientByClientId(long clientId);
        long AddClient(ClientForAddViewModel clientAddModel);
    }
}
