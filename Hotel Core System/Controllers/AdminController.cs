using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Home/index.cshtml");
        }

        public IActionResult UsersAll()
        {
            return View("~/Views/Admin/User/Index.cshtml");
        }

        public IActionResult UsersCreate()
        {
            return View("~/Views/Admin/User/Create.cshtml");
        }
        public IActionResult RolesAll()
        {
            return View("~/Views/Admin/Role/Index.cshtml");
        }

        public IActionResult RolesCreate()
        {
            return View("~/Views/Admin/Role/Create.cshtml");
        }

        public IActionResult PermissionsAll()
        {
            return View("~/Views/Admin/Permission/Index.cshtml");
        }

        public IActionResult PermissionCreate()
        {
            return View("~/Views/Admin/Permission/Create.cshtml");
        }

        public IActionResult Email()
        {
            return View("~/Views/Admin/Email/Index.cshtml");
        }

        public IActionResult SMS()
        {
            return View("~/Views/Admin/SMS/Index.cshtml");
        }

        public IActionResult Payment()
        {
            return View("~/Views/Admin/Payment/Index.cshtml");
        }

    }
}
