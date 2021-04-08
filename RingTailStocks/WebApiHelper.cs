using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RingTailStocks {
    public static class WebApiHelper {
        private static WebRequest _request;
        private const string InvestmentApi = "https://demouser.ddns.net/Investments";
        private const string ApiKey = "MUlA8CBLy1yfYqkHLgtfpVy7";

        internal static async Task<string> GetUserStocks(string userId) {
            string result;
            //MakeNewRequest
            MakeNewRequest("GET", InvestmentApi, "UserStocks", $"userId={userId}");
            try {
                // Get the response.
                WebResponse response = await _request.GetResponseAsync();
                using (var reader = new StreamReader(response.GetResponseStream())) {
                    result = reader.ReadToEnd();
                }

                // Dispose WebResponse
                response.Dispose();
            }
            catch (Exception e) {
                result = e.Message;
                Console.WriteLine(e.Message);
            }

            return result;
        }
        
        internal static async Task<string> GetUserStocksDetails(string userId, string investmentId) {
            string result;
            //MakeNewRequest
            MakeNewRequest("GET", InvestmentApi, "UserStocksByStock", $"userId={userId}&investmentId={investmentId}");
            try {
                // Get the response.
                WebResponse response = await _request.GetResponseAsync();
                using (var reader = new StreamReader(response.GetResponseStream())) {
                    result = reader.ReadToEnd();
                }

                response.Dispose();
            }
            catch (Exception e) {
                result = "Unable to complete request";
                Console.WriteLine(e.Message);
            }

            return result;
        }

        private static void MakeNewRequest(string requestType, string baseAddress, string api, string paramString) {
            SetSecurityInformation();
            var uri = $"{baseAddress}/{api}{(string.IsNullOrEmpty(paramString) ? "" : $"?{paramString}")}";
            _request = WebRequest.Create(uri);
            _request.Method = requestType;
            //Add Api Key
            _request.Headers.Add("ApiKey", ApiKey);
            // Set the ContentType property of the WebRequest.
            _request.ContentType = "application/json; charset=utf-8";
        }

        private static void SetSecurityInformation() {
            //Set protocol and SSL certification
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}