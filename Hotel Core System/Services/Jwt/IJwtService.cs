using Hotel_Core_System.Models;
using HotelAPI.Models;

namespace HotelAPI.Services.Jwt
{
    public interface IJwtService
    {
        public string GenerateToken(ApplicationUser user);
        public string ValidateToken(string token);
    }
}
