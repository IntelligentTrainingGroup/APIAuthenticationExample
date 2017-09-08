using APIAuthenticationExample.Models;
using System;
using System.Web.Mvc;

namespace APIAuthenticationExample {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ITCAuthorizeAttribute : AuthorizeAttribute {

        public enum UserRoles { Guest, RegisteredUser , Administrator};
        private UserModel user;

        public UserRoles RequiredRole { get; set; }

        public ITCAuthorizeAttribute(UserRoles requiredRole) {
            RequiredRole = requiredRole;
        }

        public ITCAuthorizeAttribute() {
            RequiredRole = UserRoles.Guest;
        }

        public override void OnAuthorization(AuthorizationContext filterContext) {
            string authenticationTicket = new ITCContext().GetAuthenticationTicket(filterContext.HttpContext.Request);
            if (!string.IsNullOrEmpty(authenticationTicket)) {
                string currentUserString = string.Format("{0}/Users/Me", Helper.ITCApiServer);
                ITCResponseModel<UserModel> userResponse = ServiceRequestor.GetRequest<ITCResponseModel<UserModel>>(currentUserString, authenticationTicket);
                user = userResponse.Data;
            }
            try {
                if (!ValidateUserRole()) {
                    throw new Exception("Invalid user role");
                }
            }
            catch (Exception ex) {
                filterContext.Result = new HttpUnauthorizedResult(ex.Message);
            }
        }

        private bool ValidateUserRole() {
            switch (RequiredRole) {
                case UserRoles.Guest:
                    return true;
                case UserRoles.RegisteredUser:
                    return 
                        user!=null &&
                        (user.UserRole.ToLower().Equals(UserRoles.RegisteredUser.ToString().ToLower()) ||
                        user.UserRole.ToLower().Equals(UserRoles.Administrator.ToString().ToLower()));
                case UserRoles.Administrator:
                    return user != null && user.UserRole.ToLower().Equals(UserRoles.Administrator.ToString().ToLower());
                default:
                return false;
            }
        }
    }
}