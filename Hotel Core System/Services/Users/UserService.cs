using Hotel_Core_System.Models;
using HotelAPI.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _db;

        public UserService(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Delete(string id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                return await _db.SaveChangesAsync();
            }
            return 400;
        }

        public ApplicationUser GetById(string id)
        {
            return _db.Users.Where(x => x.Id == id).ToList().Select(c => new ApplicationUser() { }).SingleOrDefault();
        }


        public List<ApplicationUser> GetUsersList()
        {
            var users = (from user in _db.Users
                         join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                         join roles in _db.Roles.Where(x => x.Name != Helper.Admin) on userRoles.RoleId equals roles.Id
                         select new ApplicationUser
                         {
                             Id = user.Id,
                             Name = user.Name,
                             Email = user.Email

                         }
                           ).ToList();
            return users;
        }

        public async Task<int> Update(ApplicationUser model)
        {

            //update
            var applicationUser = _db.Users.FirstOrDefault(x => x.Id == model.Id);
            applicationUser.Email = model.Email;
            applicationUser.Name = model.Name;

            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                var role = _db.UserRoles.FirstOrDefault(x => x.UserId == model.Id);
                await _db.SaveChangesAsync();
            }
            return 200;


        }
    }
}
