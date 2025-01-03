using InsuranceServiceApp.Repository.IRepository;
using InsuranceServiceApp.UnitOfWork.IUnitOfWork;

namespace InsuranceServiceApp.UnitOfWork
{
    public class ClientManagementUoW : IClientManagementUoW
    {
        public ClientManagementUoW(
            IClientRepository clientRepository, 
            IVehicleRepository vehicleRepository,
            IZoneRepository zoneRepository,
            IMakeRepository makeRepository,
            IModelRepository modelRepository,
            ILookUpRepository lookUpRepository,
            IVehicleTypeRepository vehicleTypeRepository
            )
        {
            ClientRepository = clientRepository;
            VehicleRepository = vehicleRepository;
            ZoneRepository = zoneRepository;
            MakeRepository = makeRepository;
            ModelRepository = modelRepository;
            LookUpRepository = lookUpRepository;
            VehicleTypeRepository = vehicleTypeRepository;
        }

        public IClientRepository ClientRepository { get; set; }
        public IVehicleRepository VehicleRepository { get; set; }
        public IZoneRepository ZoneRepository { get; set; }
        public IMakeRepository MakeRepository { get; set; }
        public IModelRepository ModelRepository { get; set; }
        public ILookUpRepository LookUpRepository { get; set; }
        public IVehicleTypeRepository VehicleTypeRepository { get; set; }
    }
}
