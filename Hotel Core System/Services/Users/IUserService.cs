using Hotel_Core_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Users
{
    public interface IUserService
    {
        public List<ApplicationUser> GetUsersList();
        public List<ApplicationUser> GetUsersAll();
        public Task<int> Update(ApplicationUser model);
        public ApplicationUser GetById(string id);
        public Task<int> Delete(string id);

    }
}
