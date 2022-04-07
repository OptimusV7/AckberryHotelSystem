using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Core_System.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string  Message_txt { get; set; }
        public string Recipient { get; set; }

    }
}
