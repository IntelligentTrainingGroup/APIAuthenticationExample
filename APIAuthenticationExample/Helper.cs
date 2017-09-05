using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace APIAuthenticationExample {

    public class Helper {

        public static string LoginPagePath {
            get {
                return string.Format("{0}?returnUrl={1}&app={2}", ConfigurationManager.AppSettings["ITCLoginServer"], ConfigurationManager.AppSettings["LocalLoginRedirectionPage"], ConfigurationManager.AppSettings["AppPublic"]); 
            }
        }

        public static string ITCApiServer {
            get {
                return ConfigurationManager.AppSettings["ITCApiServer"];
            }
        }

        public static string AppPrivate {
            get {
                return ConfigurationManager.AppSettings["AppPrivate"];
            }
        }
    }
}