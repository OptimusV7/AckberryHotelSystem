using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult SMS()
        {
            return View("~/Views/Admin/SMS/Index.cshtml");
        }
    }
}
