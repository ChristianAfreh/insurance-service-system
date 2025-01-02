using InsuranceServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceServiceApp.Controllers
{
    public class ClientController : Controller
    {
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
            return View(model);
        }
    }
}
