using Hotel_Core_System.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Roles
{
    public interface IRoleService
    {
        public List<IdentityRole> GetAllRoles();
        public RoleVM GetRole(int id);
        public Task<int> AddRole(IdentityRole identityRole);
    }
}
