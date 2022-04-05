using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Core_System.Models
{
    public class MessageStatus
    {
        [Key]
        public int Id { get; set; }
        public string Message_Status_Name { get; set; }
        public Message Message { get; set; }
    }
}
