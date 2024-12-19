using InsuranceServiceApp.Repository.IRepository;

namespace InsuranceServiceApp.UnitOfWork.IUnitOfWork
{
    public interface IClientManagementUoW
    {
        IClientRepository ClientRepository { get;}
    }
}
