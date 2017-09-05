using APIAuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace APIAuthenticationExample {

    public static class ServiceRequestor {

        public static t GetRequest<t>(string url, string authenticationTicket=null) {
            if (string.IsNullOrEmpty(url)) {
                throw new ArgumentNullException("No url defined.");
            }
            Uri address = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Http.Get;
            if (authenticationTicket != null) {
                request.Headers.Add("Authorization", authenticationTicket);
            }
            request.Accept = "application/json";
            request.ContentType = "application/json";

            using (WebResponse response = request.GetResponse()) {
                using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                    string text = reader.ReadToEnd();
                    return Deserialize<t>(text);
                }
            }
        }

        private static t Deserialize<t>(string json) {
            if (String.IsNullOrEmpty(json)) {
                return default(t);
            }
            try {
                if (string.IsNullOrEmpty(json)) {
                    throw new Exception("No json string defined.");
                }
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Deserialize<t>(json);
            }
            catch (Exception ex) {
                throw new Exception("Error in ServiceRequestor.Deserialize: " + ex.Message, ex);
            }
        }
    }
}