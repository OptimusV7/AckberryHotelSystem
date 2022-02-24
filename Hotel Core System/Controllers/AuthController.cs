﻿using Microsoft.AspNetCore.Mvc;

namespace Hotel_Core_System.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult index()
        {
            return View("~/Views/Auth/AdminLogin.cshtml");
        }
        public IActionResult UserRegister()
        {
            return View("~/Views/Auth/UserRegister.cshtml");
        }
    }
}
