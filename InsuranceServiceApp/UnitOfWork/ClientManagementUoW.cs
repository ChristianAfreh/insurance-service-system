using InsuranceServiceApp.Repository.IRepository;
using InsuranceServiceApp.UnitOfWork.IUnitOfWork;

namespace InsuranceServiceApp.UnitOfWork
{
    public class ClientManagementUoW : IClientManagementUoW
    {
        public ClientManagementUoW(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        public IClientRepository ClientRepository { get; set; }
    }
}
