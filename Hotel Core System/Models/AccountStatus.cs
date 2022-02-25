using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class AccountStatus
    {
        [Key]
        public int Id { get; set; }
        public string Account_status_name { get; set; }
    }
}
