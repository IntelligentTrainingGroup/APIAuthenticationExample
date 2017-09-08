using System;
using System.Web;

namespace APIAuthenticationExample {

    public class ITCContext {

        public string GetAuthenticationTicket(HttpRequestBase request) {
            HttpCookie cookie = request.Cookies["AuthExample"];
            if (cookie != null) {
                return cookie.Value.ToString();
            }
            return null;
        }

        public void SetAuthenticationTicket(string value, HttpResponseBase response) {
            HttpCookie cookie = new HttpCookie("AuthExample", value);
            cookie.Expires = DateTime.MinValue;
            response.Cookies.Add(cookie);
        }
    }
}