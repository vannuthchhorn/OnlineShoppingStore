using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnliceShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = GetConfig();
            clientId = "AaiFfwKydAjnTTkWrJ0x7BtEhMkdHapKSxui4v8QYn3m-omdQjGb75Khx9L8FoVRoiang2NkvABF3nkl";
            clientSecret = "EHjnyrcYKroJUQepG_InbhNMeaKZbgPj9L91eJB-ZqsIO7vk1UxrEWRiLhhf6ZJaDASvuU4PgqVsY5SI";
        }

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}