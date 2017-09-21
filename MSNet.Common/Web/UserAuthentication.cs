using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using MSNet.Common.Util;
namespace MSNet.Common.Web
{
    public class UserAuthentication
    {      
        public static void SignIn(SignInUser user)
        {            
            string userData = user.ToJson();
            string name = String.Format("{0}_{1}", user.PassportId, user.UserName);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), false, userData);
            string enyTicket = FormsAuthentication.Encrypt(ticket);
            string ticketCookieName = String.Format("{0}.Ticket", FormsAuthentication.FormsCookieName);
            HttpCookie cookie = new HttpCookie(ticketCookieName, enyTicket);
            cookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(cookie);
            FormsAuthentication.SetAuthCookie(FormsAuthentication.FormsCookieName, false);

        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
        public static SignInUser CurrentUser
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated) {
                    //string userData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                    string ticketCookieName = String.Format("{0}.Ticket", FormsAuthentication.FormsCookieName);
                    var cookie = HttpContext.Current.Request.Cookies[ticketCookieName];
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    string userData = ticket.UserData;
                    //string userData = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[ticketCookieName].Value).UserData; 
                    return userData.ConvertEntity<SignInUser>(); 
                }
                return null;
                
            }
        }
        public static bool IsAuthenticated 
        { 
            get 
            { 
                return HttpContext.Current.User.Identity.IsAuthenticated; 
            } 
        }
       
        public static  string LoginUrl
        {
            get
            {
                return System.Web.Security.FormsAuthentication.LoginUrl;
            }
        }
    }
}
