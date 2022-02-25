using Microsoft.AspNetCore.Identity;

namespace Hotel_Core_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
