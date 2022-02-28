using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class AccountStatus
    {
        [Key]
        public int Id { get; set; }
        public string Account_status_name { get; set; }
    }
}
