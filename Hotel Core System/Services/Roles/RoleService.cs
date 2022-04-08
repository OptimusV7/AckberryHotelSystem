using Hotel_Core_System.Models;
using Hotel_Core_System.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDBContext _dbContext;
        RoleManager<IdentityRole> _roleManager;

        public RoleService(ApplicationDBContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        public async Task<int> AddRole(IdentityRole identityRole)
        {
            var roleData = new IdentityRole
            {
                Id = identityRole.Id,
                Name = identityRole.Name,
            };
            _dbContext.Roles.Add(roleData);
            var results = await _dbContext.SaveChangesAsync();
            if (results > 0 )
            {
                return (int)TaskStatus.RanToCompletion;
            }

            return (int)TaskStatus.Faulted;
        }

        public List<IdentityRole> GetAllRoles()
        {
            var roleList = _roleManager.Roles.ToList();
            return roleList;
        }

        public RoleVM GetRole(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
