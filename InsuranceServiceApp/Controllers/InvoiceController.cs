using Microsoft.AspNetCore.Mvc;

namespace InsuranceServiceApp.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GridList()
        {
            return Json(new { });
        }
    }
}
