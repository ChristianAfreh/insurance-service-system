using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository
{
    public class VehicleTypeRepository : BaseRepository<VehicleType>, IVehicleTypeRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;

        public VehicleTypeRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }

        public SelectList  GetVehicleTypeSelectList()
        {
            var model = _insuranceDBContext.VehicleTypes.Where(x => x.ActiveFlag != (int)ActiveFlagEnum.Deleted)
                           .Select(x => new { x.TypeId, Name = $"{x.TypeName}" })
                           .ToList();

            return new SelectList(model, "TypeId", "Name");
        }
    }
}