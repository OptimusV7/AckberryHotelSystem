using Hotel_Core_System.Models;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Mpesa
{
    public interface IMpesaPayment
    {
        public MpesaRequest CreateRequest(string shortCode, int amount, string password, string timestamp,
            string transtype, string phoneNumber, string reference, string description, string callbackURL);

        public string SendCredentialsRequest();

        public string SendStkRequest(string acess_token, string json);

        public Task<int> SavePayment(MpesaCallback model);
    }
}
