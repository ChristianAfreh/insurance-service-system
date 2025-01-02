using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository
{
    public class MakeRepository : BaseRepository<Make>, IMakeRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public MakeRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }

        public SelectList GetMakeSelectList()
        {
            var model = _insuranceDBContext.Makes.Where(x => x.ActiveFlag != (int)ActiveFlagEnum.Deleted)
                           .Select(x => new { x.MakeId, Name = $"{x.Name}" })
                           .ToList();

            return new SelectList(model, "MakeId", "Name");
        }
    }
}
