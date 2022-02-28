using Hotel_Core_System.Models;
using HotelAPI.Models.ViewModels;
using HotelAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Core_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDBContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public IActionResult index()
        {
            return View("~/Views/Auth/AdminLogin.cshtml");
        }
        public IActionResult UserRegister()
        {
            return View("~/Views/Auth/UserRegister.cshtml");
        }

        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            var token = "";
            if (!result.Succeeded)
            {
                return Ok(new { Message = "Invalid Login Attempt. Check and try Again." });

            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                HttpContext.Session.SetString("ssuserName", user.Name);

                return Ok(new { user, token, Message = "Success" });
            }

            return Ok(new { user, token, Message = "Failed. Wrong Credentials" });
        }

        
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Receptionist));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Manager));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Guest));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Member));
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            var token = "";
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.RoleName);
                if (!User.IsInRole(Helper.Admin))
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                HttpContext.Session.SetString("ssuserName", user.Name);

                token = _jwtService.GenerateToken(user);
            }
            else
            {
                var errorList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.Description);
                    errorList.Add(error.Code);
                }

                return Ok(new { status = "400", errorList });

            }

            return Ok(new { result, token });

        }

        
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
