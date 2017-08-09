using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common;
using MSNet.Common.Util;
using MSNet.Common.Web;
using MSNet.Common.Web.Pager;

namespace MSNet.WebAdmin.Controllers
{
    public class PubController : Controller
    {
        //
        // GET: /Pub/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VCode()
        {
            return Content(VerifyCodeHelper.Create(new VerifyCodeHelper.VerifyCodeImageArg() { SessionName = "_Admin_VCode_SecurityCode_" }));
        }

        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult MessageAction()
        //{
        //    var vcode = Request["VCode"].ToString();
        //    if (vcode.IsNullOrEmpty())
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "请输入验证码！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    if (!VerifyCodeHelper.CheckVerifyCode(vcode, "_Message_SecurityCode_"))
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "验证码错误！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    string Name = Request["Name"],
        //           Phone = Request["Phone"],
        //           QQ = Request["QQ"],
        //           Contents = Request["Contents"];
        //    int IsAudit = 0;       
        //    if (Name.IsNullOrEmpty())
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "请输入姓名！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    if (Phone.IsNullOrEmpty())
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "请输入联系电话！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    if (Contents.IsNullOrEmpty())
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "请输入反馈内容！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    bool r = false;
        //    var m = new Message
        //    {
        //        Name = Name,
        //        Phone = Phone,
        //        QQ = QQ,
        //        Contents = Contents,
        //        IsAudit = IsAudit,
        //        AuditUser ="",
        //        AuditTime = DateTime.MinValue,
        //        CreatedTime = DateTime.Now
        //    };
        //    r = m.Save();            
            
        //    if (r)
        //    {
        //        return Json(new
        //        {
        //            success = true,
        //            message = "操作成功！"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new
        //    {
        //        success = false,
        //        message = "操作失败，请重试！"
        //    }, JsonRequestBehavior.AllowGet);
        //}

        public virtual ActionResult ErrorMsg()
        {
            ViewData["returnUrl"] = Request["returnUrl"] ?? "/";
            ViewData["second"] = Request["second"] ?? "5";
            return View();
        }

    }
}
