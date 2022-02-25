﻿using Hotel_Core_System.Models;
using HotelAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Services.Users
{
    public interface IUserService
    {
        public List<ApplicationUser> GetUsersList();
        public Task<int> Update(ApplicationUser model);
        public ApplicationUser GetById(string id);
        public Task<int> Delete(string id);

    }
}
