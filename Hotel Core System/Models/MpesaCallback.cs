using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class MpesaCallback
    {
        [Key]
        public int Id { get; set; }
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string Amount { get; set; }
        public string MpesaReceiptNumber { get; set; }
        public string TransactionDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
