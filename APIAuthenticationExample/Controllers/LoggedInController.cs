using APIAuthenticationExample.Models;
using System.Web.Mvc;

namespace APIAuthenticationExample.Controllers {

    public class LoggedInController : Controller {

        public ActionResult Index(string authenticationTicket) {

            //generating querystring to access the current user
            string currentUserString = string.Format("{0}/Users/Me", Helper.ITCApiServer);
            ITCResponseModel<UserModel> userResponse = ServiceRequestor.GetRequest<ITCResponseModel<UserModel>>(currentUserString, authenticationTicket);
            UserModel userModel = userResponse.Data;

            //(UNUSED IN THIS SCENARIO) generating querystring to logout the current user (inactivate the authentication ticket)
            string logoutString = string.Format("{0}/Users/Me/Logout", Helper.ITCApiServer);

            return View(new LoggedInModel() {
                AuthenticationTicket = authenticationTicket,
                UserModel = userModel
            });
        }
    }
}