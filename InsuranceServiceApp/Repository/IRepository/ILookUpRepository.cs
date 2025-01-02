using InsuranceServiceApp.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface ILookUpRepository : IBaseRepository<LookUp>
    {
        SelectList GetLookupSelectList(int lookupCodeId, object? selectedValue = null);
    }
}
