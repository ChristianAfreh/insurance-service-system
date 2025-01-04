using InsuranceServiceApp.Extensions;
using InsuranceServiceApp.Models;
using InsuranceServiceApp.Services.IServices;
using InsuranceServiceApp.Utility;
using InsuranceServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceServiceApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GridList([FromBody] DatatableRequestModel requestModel)
        {
            var clientVehicleData = _clientService.GetClientVehicleListForGridDisplay();

            var query = clientVehicleData.AsQueryable();

            var filteredQuery = query;

            //Apply global search filter if present
            if (!string.IsNullOrEmpty(requestModel.Search.Value))
            {
                filteredQuery = filteredQuery.Where(c => c.Surname.ToLower().Contains(requestModel.Search.Value.ToLower()) ||
                    c.Othername.ToLower().Contains(requestModel.Search.Value.ToLower()) ||
                    c.MakeModel.ToLower().Contains(requestModel.Search.Value.ToLower()) ||
                    c.Cellphone.ToLower().Contains(requestModel.Search.Value.ToLower()) ||
                    c.Email.ToLower().Contains(requestModel.Search.Value.ToLower())     ||
                    c.RegistrationNo.ToLower().Contains(requestModel.Search.Value.ToLower()) ||
                    c.Zone.ToLower().Contains(requestModel.Search.Value.ToLower())
                );
            }

            //Pagination 
            var data = filteredQuery.Skip(requestModel.Start).Take(requestModel.Length).ToList();

            var response = new
            {
                draw = requestModel.Draw,
                recordsTotal = query.Count(),
                recordsFiltered = filteredQuery.Count(),
                data = data
            };

            return Json(response);
        }

        public IActionResult AddClient()
        {
            var model = new ClientVehicleForAddEditViewModel
            {
                ClientForAddVm = new ClientForAddViewModel(),
                VehicleForAddVm = new VehicleForAddViewModel()
            };

            var selectLists = _clientService.GetSelectListsForClientVehicleAdd();

            ViewBag.ZoneList = selectLists.ZoneSelectList;
            ViewBag.MakeList = selectLists.MakeSelectList;
            ViewBag.ModelList = selectLists.ModeSelectList;
            ViewBag.ColourList = selectLists.ColourSelectList;
            ViewBag.VehicleTypeList = selectLists.VehicleTypeSelectList;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddClient(ClientVehicleForAddEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clientService.AddClientVehicleData(model);
                    return Ok(new { success = true, message = $"Successfully added client and vehicle data." });
                }
                else
                {
                    string modelStateErrorsStr = GlobalFunctions.GetModelStateErrors(ModelState);
                    throw new CustomException(modelStateErrorsStr);
                }
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;

                return Ok(new {success = false, message = errMsg });
            }
            
        }
    }
}
