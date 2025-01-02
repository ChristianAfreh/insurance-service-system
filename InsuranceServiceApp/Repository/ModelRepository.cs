using InsuranceServiceApp.Models;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        private readonly InsuranceSystemDBContext _insuranceDBContext;
        public ModelRepository(InsuranceSystemDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }

        public SelectList GetModelSelectList()
        {
            var model = _insuranceDBContext.Models.Where(x => x.ActiveFlag != (int)ActiveFlagEnum.Deleted)
                           .Select(x => new { x.ModelId, Name = $"{x.Name}" })
                           .ToList();

            return new SelectList(model, "ModelId", "Name");
        }
    }
}
