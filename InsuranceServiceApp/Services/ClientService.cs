using AutoMapper;
using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Services.IServices;
using InsuranceServiceApp.UnitOfWork.IUnitOfWork;
using InsuranceServiceApp.ViewModels;

namespace InsuranceServiceApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientManagementUoW _clientManagementUoW;
        private readonly IMapper _mapper;
        public ClientService(IClientManagementUoW clientManagementUoW, IMapper mapper)
        {
            _clientManagementUoW = clientManagementUoW;
            _mapper = mapper;
        }

        public IEnumerable<ClientViewModel> GetAllClients()
        {
            var clientsData = _clientManagementUoW.ClientRepository.Query(c => c.ActiveFlag != (int)ActiveFlagEnum.Deleted).ToList();

            var clientsVM = _mapper.Map<IEnumerable<ClientViewModel>>(clientsData);

            return clientsVM;

        }

        public ClientViewModel GetClientByClientId(long clientId)
        {
            var clientData = _clientManagementUoW.ClientRepository.Query(c => c.ClientId == clientId && c.ActiveFlag != (int)ActiveFlagEnum.Deleted).FirstOrDefault();

            var clientVM = _mapper.Map<ClientViewModel>(clientData);

            return clientVM;
        }

        public long AddClient(ClientForAddViewModel clientAddModel)
        { 
            var clientToAdd = _mapper.Map<Client>(clientAddModel);
            clientToAdd.ActiveFlag = (int)ActiveFlagEnum.Active;
            clientToAdd.DateCreated = DateTime.UtcNow;
            clientToAdd.CreateAppUserId = 1;
            clientToAdd.LastDateUpdated = DateTime.UtcNow;
            clientToAdd.LastUpdateAppUserId = 1;

            _clientManagementUoW.ClientRepository.Create(clientToAdd);
            _clientManagementUoW.ClientRepository.SaveChanges();

            return clientToAdd.ClientId;
        }


       // private int SaveClientVehicle(long clientId,)
    }
}
