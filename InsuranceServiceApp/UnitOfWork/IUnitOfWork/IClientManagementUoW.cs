using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.UnitOfWork.IUnitOfWork
{
    public interface IClientManagementUoW
    {
        IClientRepository ClientRepository { get;}
        IVehicleRepository VehicleRepository { get;}
        IZoneRepository ZoneRepository { get;}
        IMakeRepository MakeRepository { get;}
        IModelRepository ModelRepository { get;}
        ILookUpRepository LookUpRepository { get;}
        IVehicleTypeRepository VehicleTypeRepository { get;}
    }
}
