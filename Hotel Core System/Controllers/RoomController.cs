using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomDetails()
        {
            return View();
        }
    }
}
