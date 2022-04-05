using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Core_System.Models.ViewModels
{
    public class UserAddVM
    {
        [Required, Display(Name = "User Name")]
        public string Name { get; set; }
        [Required,Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required, Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Image")]
        public string imageName { get; set; }
        [Required,Display(Name = "Assign Role")]
        public string roleName { get; set; }
        [Display(Name = "Chat Message")]
        public string Message { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
