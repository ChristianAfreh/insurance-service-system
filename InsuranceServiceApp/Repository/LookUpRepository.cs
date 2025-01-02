using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository
{
    public class LookUpRepository : BaseRepository<LookUp>, ILookUpRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public LookUpRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }

        public SelectList GetLookupSelectList(int lookupCodeId, object? selectedValue = null)
        {
            var model = _insuranceDBContext.LookUps.Where(x => x.ActiveFlag == (int)ActiveFlagEnum.Active && x.LookUpCodeId == lookupCodeId)
                .Select(x => new { x.ShortName, x.FullName })
                .ToList();
            if (selectedValue != null)
            {
                return new SelectList(model, "ShortName", "FullName", selectedValue);
            }
            else
            {
                return new SelectList(model, "ShortName", "FullName");
            }

        }
    }
}
