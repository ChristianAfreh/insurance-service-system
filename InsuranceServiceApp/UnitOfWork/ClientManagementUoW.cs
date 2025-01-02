using InsuranceServiceApp.Repository.IRepository;
using InsuranceServiceApp.UnitOfWork.IUnitOfWork;

namespace InsuranceServiceApp.UnitOfWork
{
    public class ClientManagementUoW : IClientManagementUoW
    {
        public ClientManagementUoW(
            IClientRepository clientRepository, 
            IZoneRepository zoneRepository,
            IMakeRepository makeRepository,
            IModelRepository modelRepository,
            ILookUpRepository lookUpRepository
            )
        {
            ClientRepository = clientRepository;
            ZoneRepository = zoneRepository;
            MakeRepository = makeRepository;
            ModelRepository = modelRepository;
            LookUpRepository = lookUpRepository;
        }

        public IClientRepository ClientRepository { get; set; }
        public IZoneRepository ZoneRepository { get; set; }
        public IMakeRepository MakeRepository { get; set; }
        public IModelRepository ModelRepository { get; set; }
        public ILookUpRepository LookUpRepository { get; set; }
    }
}
