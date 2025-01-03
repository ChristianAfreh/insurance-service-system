﻿using InsuranceServiceApp.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceServiceApp.Repository.IRepository
{
    public interface IModelRepository : IBaseRepository<Model>
    {
        SelectList GetModelSelectList();
    }
}
