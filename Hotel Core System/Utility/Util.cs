using Hotel_Core_System.Models;
using HotelAPI.Services.LogManagerConf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelAPI.Utility
{
    public class Util
    {
        public static readonly string BuyGoodsTransaction = "CustomerBuyGoodsOnline";
        public static readonly string PayBillTransaction = "CustomerPayBillOnline";

        private readonly ILoggerManager log;

        public Util(ILoggerManager loggerManager)
        {
            log = loggerManager;
        }

        public static string RequestJSON(MpesaRequest request)
        {
            return JsonConvert.SerializeObject(request);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string RNGCharacterMask()
        {
            int maxSize = 10;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString().ToLower();
        }
        public static  string GetReference()
        {
            try
            {
                return RNGCharacterMask();
            }
            catch (Exception ex)
            {
                LoggerManager loggers = new LoggerManager();
                loggers.LogInformation(ex.Message);
            }

            return "";
        }

        public static string IsValidMobile( string Mobile)
        {
            string __Mobile;
            string CountryCode;
            int nsnLength = 9;
            CountryCode = "254";
            int msisdnLen = 12;

            Mobile = Mobile.TrimStart(new Char[] { '0' });
            __Mobile = CountryCode + Mobile.Substring(Mobile.Length - nsnLength);

            if (__Mobile.Length == msisdnLen)
                return __Mobile;

            return Mobile;
        }

        public static string TimeStamp()
        {
            DateTime dt = DateTime.Now;
            return dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0') + dt.Hour.ToString().PadLeft(2, '0') + dt.Minute.ToString().PadLeft(2, '0') + dt.Second.ToString().PadLeft(2, '0');
        }



        public enum OnlineTrxType
        {
            BuyGoods, PayBill
        }

        public class CredentialsResponse
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
        }

       

        public class MpesaSuccessResponse
        {
            public Body Body { get; set; }
        }

        public class Body
        {
            public StkCallback stkCallback { get; set; }
        }

        public class StkCallback
        {
            public string MerchantRequestID { get; set; }
            public string CheckoutRequestID { get; set; }
            public int ResultCode { get; set; }
            public string ResultDesc { get; set; }
            public CallbackMetadata CallbackMetadata { get; set; }
        }

        public class CallbackMetadata
        {
            public List<Item> Item { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}
