using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository
{
    public class LookUpCodeRepository : BaseRepository<LookUpCode>, ILookUpCodeRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public LookUpCodeRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }

        //public SelectList GetLookupCodeById(int lookupCodeId)
        //{
        //    var model = _insuranceDBContext.LookUpCodes.Where(x => x.ActiveFlag == (int)ActiveFlagEnum.Active)
        //        .Select(x => new { x.LookUpCodeId,x.LookUpShortCode, x.LookUpName })
        //        .ToList();
        //    return new SelectList(model,"LookUpCodeId", "ShortName", "FullName");
        //}
    }
}
