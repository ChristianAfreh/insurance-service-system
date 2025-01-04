using AutoMapper;
using InsuranceServiceApp.Extensions;
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

        public IEnumerable<GetClientVehicleList_Result>  GetClientVehicleListForGridDisplay()
        {
            var clientVehicleData = _clientManagementUoW.ClientRepository.GetClientVehicleList();

            return clientVehicleData;      
        }

        public ClientViewModel GetClientByClientId(long clientId)
        {
            var clientData = _clientManagementUoW.ClientRepository.Query(c => c.ClientId == clientId && c.ActiveFlag != (int)ActiveFlagEnum.Deleted).FirstOrDefault();

            var clientVM = _mapper.Map<ClientViewModel>(clientData);

            return clientVM;
        }

        public void AddClientVehicleData(ClientVehicleForAddEditViewModel clientVehicleAddModel)
        {

            if (clientVehicleAddModel is null)
                throw new CustomException("ClientVehicle data is null.");

            using (var transaction = _clientManagementUoW.ClientRepository.GetTransaction()) 
            {
                try
                {
                    var clientDataForAdd = new ClientForAddViewModel
                    {
                        ZoneId = clientVehicleAddModel.ClientForAddVm.ZoneId,
                        Surname = clientVehicleAddModel.ClientForAddVm.Surname,
                        Othername = clientVehicleAddModel.ClientForAddVm.Othername,
                        Cellphone = clientVehicleAddModel.ClientForAddVm.Cellphone,
                        Email = clientVehicleAddModel.ClientForAddVm.Email,
                        BirthDate = clientVehicleAddModel.ClientForAddVm.BirthDate,
                        ResidentialAddress = clientVehicleAddModel.ClientForAddVm.ResidentialAddress,
                        PostalAddress = clientVehicleAddModel.ClientForAddVm.PostalAddress,
                        Employer = clientVehicleAddModel.ClientForAddVm.Employer,
                        ActiveFlag = (int)ActiveFlagEnum.Active,
                        DateCreated = DateTime.UtcNow,
                        CreateAppUserId = 1,  // replace with logged in user id
                        LastDateUpdated = DateTime.UtcNow,
                        LastUpdateAppUserId = 1, // replace with logged in user id
                    };

                    // Call private method to save Client data
                    var clientId = SaveClientData(clientDataForAdd);

                    var vehicleDataForAdd = new VehicleForAddViewModel
                    {
                        ClientId = clientId,
                        ModelId = clientVehicleAddModel.VehicleForAddVm.ModelId,
                        TypeId = clientVehicleAddModel.VehicleForAddVm.TypeId,
                        RegistrationNo = clientVehicleAddModel.VehicleForAddVm.RegistrationNo,
                        InsuranceDate = clientVehicleAddModel.VehicleForAddVm.InsuranceDate,
                        ColourCode = clientVehicleAddModel.VehicleForAddVm.ColourCode,
                        ActiveFlag = (int)ActiveFlagEnum.Active,
                        DateCreated = DateTime.UtcNow,
                        CreateAppUserId = 1, // replace with logged in user id
                        LastDateUpdated = DateTime.UtcNow,
                        LastUpdateAppUserId = 1, // replace with logged in user id
                    };

                    // Call private method to save Vehicle data
                    SaveVehicleData(vehicleDataForAdd);
                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException($"Attempt to save client vehicle data failed with error: {ex.Message}");
                }
            }
        }


        //Get SelectLists
        public ClientVehicleForAddSelectListViewModel GetSelectListsForClientVehicleAdd()
        {
            var zoneList = _clientManagementUoW.ZoneRepository.GetLocationSelectList();

            var makeList = _clientManagementUoW.MakeRepository.GetMakeSelectList();

            var modelList = _clientManagementUoW.ModelRepository.GetModelSelectList();

            var colourList = _clientManagementUoW.LookUpRepository.GetLookupSelectList((int)LookUpCodeIdEnum.Colour);
            
            var vehicleTypeList = _clientManagementUoW.VehicleTypeRepository.GetVehicleTypeSelectList();

            var selectListsVm = new ClientVehicleForAddSelectListViewModel
            {
                ZoneSelectList = zoneList,
                MakeSelectList = makeList,
                ModeSelectList = modelList,
                ColourSelectList = colourList,
                VehicleTypeSelectList = vehicleTypeList,
            };

            return selectListsVm;
        }

       private long SaveClientData(ClientForAddViewModel clientModelForAdd)
        {
            var clientToAdd = _mapper.Map<Client>(clientModelForAdd);

            _clientManagementUoW.ClientRepository.Create(clientToAdd);
            _clientManagementUoW.ClientRepository.SaveChanges();

            return clientToAdd.ClientId;
        }


        private void SaveVehicleData(VehicleForAddViewModel vehicleModelForAdd)
        {
            var vehicleToAdd = _mapper.Map<Vehicle>(vehicleModelForAdd);

            _clientManagementUoW.VehicleRepository.Create(vehicleToAdd);
            _clientManagementUoW.VehicleRepository.SaveChanges();

        }


    }


}
