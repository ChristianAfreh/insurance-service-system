using InsuranceServiceApp.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IZoneRepository : IBaseRepository<Zone>
    {
        SelectList GetLocationSelectList();
    }
}
