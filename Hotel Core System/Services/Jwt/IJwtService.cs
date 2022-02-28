using Hotel_Core_System.Models;

namespace Hotel_Core_System.Services.Jwt
{
    public interface IJwtService
    {
        public string GenerateToken(ApplicationUser user);
        public string ValidateToken(string token);
    }
}
