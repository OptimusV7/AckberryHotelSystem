using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Email()
        {
            return View("~/Views/Admin/Email/Index.cshtml");
        }
    }
}
