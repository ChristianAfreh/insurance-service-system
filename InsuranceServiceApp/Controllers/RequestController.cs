using Microsoft.AspNetCore.Mvc;

namespace InsuranceServiceApp.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GridList()
        {
            return Json(new { });
        }

        public IActionResult AddRequest()
        {
            return View();
        }
    }
}
