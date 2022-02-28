using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class PaymentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Payment_status_name { get; set; }
    }
}
