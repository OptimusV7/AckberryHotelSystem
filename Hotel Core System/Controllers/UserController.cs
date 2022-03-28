using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class UserController : Controller
    {
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
    }
}
