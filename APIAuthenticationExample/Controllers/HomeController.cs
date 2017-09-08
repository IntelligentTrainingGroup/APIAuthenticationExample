using APIAuthenticationExample.Models;
using System.Web.Mvc;

namespace APIAuthenticationExample.Controllers {

    public class HomeController : Controller {

        // GET: Home
        public ActionResult Index() {
            if (new ITCContext().GetAuthenticationTicket(Request) == null) {
              return Redirect(Helper.LoginPagePath);
            }
            else {
              return RedirectToAction("Index", "LoggedIn");
            }
            //LoginModel model = new LoginModel() {
            //    LoginPagePath = Helper.LoginPagePath
            //};
            //return View(model);
        }
    }
}