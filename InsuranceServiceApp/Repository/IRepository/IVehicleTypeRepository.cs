using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IVehicleTypeRepository
    {
        SelectList GetVehicleTypeSelectList();
    }
}
