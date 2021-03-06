using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Hotel_Core_System.Services.Messages;
using Hotel_Core_System.Services.Roles;
using Hotel_Core_System.Services.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMessageService _messageService;
        private readonly IEmailSender _emailSender;
        private readonly IRoleService _roleService;

        public UserController(ApplicationDBContext _context, UserManager<ApplicationUser> userManager, IUserService userService, RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment hostEnvironment, IMessageService messageService, IEmailSender emailSender, IRoleService roleService)
        {
            _db = _context;
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
            _hostEnvironment = hostEnvironment;
            _messageService = messageService;
            _emailSender = emailSender;
            _roleService = roleService;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostUser(UserAddVM model)
        {
            ViewBag.RoleList = _roleManager.Roles.ToList();
            if (ModelState.IsValid)
            {
                //save image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.imageName = fileName;
                string path = Path.GetFullPath(Path.Combine(wwwRootPath + "/images/", fileName)).Replace(@"\\", @"\");
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    img_url = model.imageName
                };

                var messReq = new Message
                {
                    Message_txt = model.Message,
                    Recipient = model.Name
                };

                // save message
                var messageResult = _messageService.AddMessage(messReq);

                var role = model.roleName;
                var roleResult = _db.Roles.FindAsync(role);
                var result = await _userManager.CreateAsync(user, model.Password);

                //save message status
                var messageStatusResult = _messageService.AddMessageStatus(messReq); 

                if (result.Succeeded )
                {
                    await _userManager.AddToRoleAsync(user, roleResult.Result.Name);

                    //send email confirmation
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { token, email = user.Email }, Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Account Created",
                            $"You can use your email {user.Email} and password {model.Password} to access the " +
                            $"account once you have confirmed your account here ->" +
                            $" {confirmationLink}");

                    return RedirectToAction("UsersAll", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("~/Views/Admin/User/Create.cshtml", model);
        }
        public IActionResult RolesAll()
        {
            var roles = _roleService.GetAllRoles();
            return View("~/Views/Admin/Role/Index.cshtml", roles);
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
