using APIAuthenticationExample.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace APIAuthenticationExample.Controllers {

    public class OnLoginController : Controller {

        // GET: OnLogin
        public ActionResult Index(string appauth) {

            //generating querystring to access api server and retrieve authentication ticket
            string authString = string.Format("{0}/Auth/{1}/{2}", Helper.ITCApiServer, appauth, Helper.AppPrivate);

            // get the authentication ticket
            ITCResponseModel<string> authenticationTicketResponse = ServiceRequestor.GetRequest<ITCResponseModel<string>>(authString);

            //Remember this. You have to use it in every query against the api
            string authenticationTicket = authenticationTicketResponse.Data;

            new ITCContext().SetAuthenticationTicket(authenticationTicket, Response);

            return RedirectToAction("Index", "LoggedIn");
        }
    }
}