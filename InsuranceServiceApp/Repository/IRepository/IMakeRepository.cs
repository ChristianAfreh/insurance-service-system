using InsuranceServiceApp.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IMakeRepository : IBaseRepository<Make>
    {
        SelectList GetMakeSelectList();
    }
}
