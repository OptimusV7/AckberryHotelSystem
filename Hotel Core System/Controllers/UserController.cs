﻿using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;
        UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDBContext _context, UserManager<ApplicationUser> userManager)
        {
            _db = _context;
            _userManager = userManager;
        }

        public IActionResult UsersAll()
        {
            var userlist = (from user in _db.Users
                            select new AccountVM
                            {
                                Id = user.Id,
                                UserName = user.UserName,
                                Name = user.Name,
                                Email = user.Email,
                                EmailConfirmed = user.EmailConfirmed,
                                Phone = user.PhoneNumber
                            }).ToList();

            return View("~/Views/Admin/User/Index.cshtml", userlist);
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

        public IActionResult GetUsers()
        {
            var userList = _userManager.Users;

            return (IActionResult)userList;
        }
        
    }
}
