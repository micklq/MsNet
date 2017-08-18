using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSNet.Common.Util;
namespace MSNet.Common.Web
{
    public class AuthBaseController : BaseController
    {

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!UserAuthentication.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(UserAuthentication.LoginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.ToString().UrlEncode());
                return;
            }
        }
        public SignInUser CurrentUser
        {
            get
            {
                if (UserAuthentication.IsAuthenticated)
                {
                    return UserAuthentication.CurrentUser;
                }
                return null;
            }
        }

        public ActionResult SignOut()
        {
            UserAuthentication.SignOut();
            return Redirect(UserAuthentication.LoginUrl);
        }
      
       

    }
}
