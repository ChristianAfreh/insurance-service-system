using InsuranceServiceApp.Extensions;
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

        public IActionResult GridList()
        {
            return Json(new { });
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
