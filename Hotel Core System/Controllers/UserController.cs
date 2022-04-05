using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Hotel_Core_System.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;
        UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        RoleManager<IdentityRole> _roleManager;

        public UserController(ApplicationDBContext _context, UserManager<ApplicationUser> userManager, IUserService userService, RoleManager<IdentityRole> roleManager)
        {
            _db = _context;
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
        }

        public IActionResult UsersAll()
        {
            var users = _userService.GetUsersAll();

            return View("~/Views/Admin/User/Index.cshtml", users);
        }

        public IActionResult AddUser()
        {
            ViewBag.RoleList = _roleManager.Roles.ToList();
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

        public IActionResult GetUsers()
        {
            var userList = _userManager.Users;

            return (IActionResult)userList;
        }
        
    }
}
