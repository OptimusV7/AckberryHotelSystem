using HotelAPI.Models;
using System.Threading.Tasks;

namespace HotelAPI.Services.Mpesa
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
