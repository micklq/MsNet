using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSNet.Common;
using MSNet.Common.Util;
using MSNet.Common.Web;
using MSNet.Common.Passports;
namespace MSNet.WebAdmin.Controllers
{
    public class AuthController : Controller
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
                return Json(new
                {
                    success = false,
                    message = "请输入用户名或密码！"
                }, JsonRequestBehavior.AllowGet);
            }
            var vcode = Request["Vcode"].ToString();
            if (vcode.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入验证码！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!VerifyCodeHelper.CheckVerifyCode(vcode))
            {
                return Json(new
                {
                    success = false,
                    message = "验证码错误！"
                }, JsonRequestBehavior.AllowGet);
            }
            UserPassport uPassport =null;
            var u = MemberShip.SignIn(uname, upass, out uPassport);
            if (uPassport!=null&&uPassport.UserSecurity.IsLocked)
            {
                return Json(new
                {
                    success = false,
                    message = "用户名已锁定！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!u)
            {                
                return Json(new
                {
                    success = false,
                    message = "用户名或密码错误！"
                }, JsonRequestBehavior.AllowGet);
            }
          
            SignInUser uSign = new SignInUser { 
                PassportId = uPassport.PassportId, 
                UserName = uPassport.UserName,
                Roles = uPassport.Roles,
                RolePermissions = (uPassport.RolePermissions != null) ? uPassport.RolePermissions : null 
            };
            UserAuthentication.SignIn(uSign);

            var returnUrl = (Request["returnUrl"] ?? "");
            if (returnUrl.IsNullOrEmpty())
            {
                returnUrl = "/admin/index";
            }
            return Json(new
            {
                success = true,
                message = returnUrl
            }, JsonRequestBehavior.AllowGet);
        }

        

    }
}
