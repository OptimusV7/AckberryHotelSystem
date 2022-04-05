using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using static Hotel_Core_System.Models.ApplicationDBContext;

namespace Hotel_Core_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string img_url { get; set; }

    }
}
