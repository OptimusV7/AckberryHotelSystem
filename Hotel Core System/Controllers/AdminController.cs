using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Home/index.cshtml");
        }

    }
}
