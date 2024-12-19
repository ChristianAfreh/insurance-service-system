using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace InsuranceServiceApp.Repository
{
    public class ZoneRepository : BaseRepository<Zone>, IZoneRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public ZoneRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }


        public SelectList GetLocationSelectList()
        {
            var model = _insuranceDBContext.Zones.Where(x => x.ActiveFlag != (int)ActiveFlagEnum.Deleted)
                           .Select(x => new { x.ZoneId, Name = $"{x.Name}" })
                           .ToList();

            return new SelectList(model, "ZoneId", "Name");
        }
       
    }
}
