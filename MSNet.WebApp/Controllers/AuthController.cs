using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSNet.Common;
using MSNet.Common.Util;
using MSNet.Common.Web;
namespace MSNet.WebAdmin.Controllers
{
    public class AuthController : BaseController
    {       

        public ActionResult VCode()
        {
            return Content(VerifyCodeHelper.Create(new VerifyCodeHelper.VerifyCodeImageArg()));
        }

        //
        // GET: /Auth/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            string uname = Request["uName"].ToString(),
                      upass = Request["uPass"].ToString();
            if (uname.IsNullOrEmpty() || upass.IsNullOrEmpty())
            {
                return JsonFail("请输入用户名或密码！");
            }    

            UserPassport uPassport = null;          
            var result = MemberShip.SignIn(uname, upass, out uPassport);
            WebAppLogsWrite(uPassport.PassportId, uname, "用户登录", result.message); // 写入日志      
            if (!result.success) {
                return JsonFail(result.message);
            }            
            SignInUser uSign = new SignInUser { 
                PassportId = uPassport.PassportId, 
                UserName = uPassport.UserName,
                RoleId = uPassport.RoleId,
                RoleName = (uPassport.Role != null) ? uPassport.Role.Name : null               
            };
            UserAuthentication.SignIn(uSign);   

            var returnUrl = (Request["returnUrl"] ?? "");
            if (returnUrl.IsNullOrEmpty())
            {
                returnUrl = "/admin/index";
            }
            return JsonSuccess(returnUrl);   

        }

        public ActionResult SignOut()
        {
            UserAuthentication.SignOut();
            return Redirect(UserAuthentication.LoginUrl);
        }

        

    }
}
