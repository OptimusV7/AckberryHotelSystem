using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class PaymentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Payment_status_name { get; set; }
    }
}
