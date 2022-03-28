using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View("~/Views/Admin/Payment/Index.cshtml");
        }
    }
}
