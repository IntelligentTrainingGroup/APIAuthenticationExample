using APIAuthenticationExample.Models;
using System.Web.Mvc;

namespace APIAuthenticationExample.Controllers {

    public class HomeController : Controller {

        // GET: Home
        public ActionResult Index() {
            LoginModel model = new LoginModel() {
                LoginPagePath = Helper.LoginPagePath
            };
            return View(model);
        }
    }
}