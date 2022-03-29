using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hotel_Core_System.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
