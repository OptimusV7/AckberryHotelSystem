using Hotel_Core_System.Models;
using HotelAPI.Services.LogManagerConf;
using HotelAPI.Utility;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelAPI.Services.Mpesa
{
    public class MpesaPayment : IMpesaPayment
    {
        public static readonly string BuyGoodsTransaction = "CustomerBuyGoodsOnline";
        public static readonly string PayBillTransaction = "CustomerPayBillOnline";

        private readonly ILoggerManager logger;
        private readonly ApplicationDBContext _dbContext;

        private readonly MpesaSettings _mpesaSettings;
        public MpesaPayment(IOptions<MpesaSettings> mpesaSettings, ILoggerManager loggerManager, ApplicationDBContext dBContext)
        {
            _mpesaSettings = mpesaSettings.Value;
            logger = loggerManager;
            _dbContext = dBContext;
        }

        public MpesaRequest CreateRequest(string shortCode, int amount, string password, string timestamp,
            string transtype, string phoneNumber, string reference, string description, string callbackURL)
        {
            MpesaRequest req = new MpesaRequest
            {
                BusinessShortCode = shortCode,
                Password = password,
                Timestamp = timestamp,
                //TransactionType = type == OnlineTrxType.BuyGoods ? BuyGoodsTransaction : PayBillTransaction,
                TransactionType = "CustomerPayBillOnline",
                PartyA = phoneNumber,
                PartyB = shortCode,
                Amount = amount,
                PhoneNumber = phoneNumber,
                CallBackURL = callbackURL,
                AccountReference = reference,
                TransactionDesc = description
            };
            return req;
        }

        public async Task<int> SavePayment(MpesaCallback model)
        {
            _dbContext.MpesaCallbacks.Add(model);
            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                logger.LogInformation(results.ToString());
            }
            logger.LogInformation(results.ToString());

            return 200;
        }

        public string SendCredentialsRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_mpesaSettings.credential_url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers["Authorization"] = "Basic " + Util.Base64Encode(_mpesaSettings.consumer_key + ":" + _mpesaSettings.consumer_secret);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public string SendStkRequest(string acess_token, string json)
        {
            string erMsg = "";
            try
            {
                WebRequest webRequest = WebRequest.Create(_mpesaSettings.test_url);
                HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";
                httpRequest.Headers.Add("Authorization", "Bearer " + acess_token);
                httpRequest.ProtocolVersion = HttpVersion.Version11;
                Stream requestStream = httpRequest.GetRequestStream();
                StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);
                httpRequest.ProtocolVersion = HttpVersion.Version11;
                //Log.Error(json);
                System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;

                streamWriter.Write(json);
                streamWriter.Close();

                HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());

                string resulXmlFromWebService = srd.ReadToEnd();
                return resulXmlFromWebService;

            }
            catch (WebException ex)
            {
                string res = "";
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    res = reader.ReadToEnd();
                }

                if (string.IsNullOrEmpty(res))
                    erMsg = ex.Message;
                else
                {

                    JObject req = JObject.Parse(res);
                    string requestId = (string)req["requestId"];
                    string errorCode = (string)req["errorCode"];
                    string errorMessage = (string)req["errorMessage"];


                    JObject resp = new JObject();
                    req["ResponseCode"] = errorCode;
                    req["ResponseDescription"] = errorMessage;
                    req["ConversationID"] = "";
                    req["OriginatorConversationID"] = "";

                    return req.ToString();


                }
            }
            catch (Exception ex)
            {
                erMsg = ex.Message;
                //Log.Error(ex.ToString());
            }

            string[] erData = Regex.Split(erMsg, ":");
            if (erData.Length > 1)
            {
                string Res = erData[1].Trim().Replace("(", "").Replace(")", "");
                JObject req = new JObject();
                req["ResponseCode"] = Res.Substring(0, 3);
                req["ResponseDescription"] = Res.Remove(0, 3).Trim();
                req["ConversationID"] = "";
                req["OriginatorConversationID"] = "";

                return req.ToString();
            }
            return "";
        }
    }
}
