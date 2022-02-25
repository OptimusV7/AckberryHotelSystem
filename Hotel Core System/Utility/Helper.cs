namespace HotelAPI.Utility
{
    public class Helper
    {
        //status codes
        public static int success_code = 200;
        public static int failure_code = 400;

        //message responses
        public static string roomAdded = "Room Added Successfully";
        public static string roomUpdated = "Room Updated Successfully";
        public static string roomDeleted = "Room Deleted Successfully";
        public static string roomList = "Successfully";
        public static string failure = "Failure processing Data";

        //callback responses
        public static string ResultCodeSuccess = "0";
        public static string ResultCodeRejectByUser = "1032";
        public static string ResultCodeInvalidDataUser = "2001";
        public static string ResultCodeLimit = "17";
        public static string SucccessMpesa = "The service request is processed successfully.";
        public static string ErrorMpesa = "Error while processing request";
        public static string ErrorMpesaRejectByUser = "Request cancelled by user";
        public static string ErrorMpesaInvalidDataUser = "Invalid Data";
        public static string ErrorMpesaLimit = "Rule limited. Another similar Transaction is being processed. Please wait";

        //Users
        public static string InitPass = "OptimusV7@!";
        public static string InitEmail = "admin@mail.com";
        public static string Admin = "Admin";
        public static string Receptionist = "Receptionist";
        public static string Manager = "Manager";
        public static string Guest = "Guest";
        public static string Member = "Member";
        public static string System = "System";
        public static string Supervisor = "Supervisor";
        public static string delete_success = "Deleted Successfully";
        public static string update_success = "Update Successfully";
        //Room Status
        public static string Available = "Available";
        public static string Occupied = "Occupied";
        public static string NotAvailable = "Not Available";
        public static string BeignServiced = "Beign Serviced";
        public static string Other = "Other";
        //Room Type
        public static string Standard = "Standard";
        public static string Deluxe = "Deluxe";
        public static string Executive = "Executive";
        public static string OneBedroom = "1 Bedroom";
        public static string TwoBedroom = "2 Bedroom";
        public static string ThreeBedroom = "3 Bedroom";
        //Booking Status
        public static string Requested = "Requested";
        public static string Pending = "Pending";
        public static string Confirmed = "Confirmed";
        public static string Checked_in = "Checked-in";
        public static string Checked_out = "Checked-out";
        public static string Abandoned = "Abandoned";
        //Account status
        public static string Active = "Active";
        public static string closed = "Closed";
        public static string Cancelled = "Cancelled";
        public static string Blacklisted = "Blacklisted";
        //Payment status
        public static string Unpaid = "Unpaid";
        public static string PendingPayment = "Pending Payment";
        public static string CompletedPayment = "Completed Payment";
        public static string FailedPayment = "Failed Payment";
        public static string DeclinedPayment = "Declined Payment";
        public static string CancelledPayment = "Cancelled Payment";
        public static string AbandonedPayment = "Abandoned Payment";
        public static string RefundedPayment = "Refunded Payment";





    }
}
