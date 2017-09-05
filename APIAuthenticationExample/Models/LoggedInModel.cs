namespace APIAuthenticationExample.Models {

    public class LoggedInModel {

        public string AuthenticationTicket { get; set; }
        public UserModel UserModel { get; set; }
    }
}