using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Util;
using MSNet.Common.Web;
using MSNet.Common.Web.Pager;
using MSNet.Common.Passports;

namespace MSNet.WebApp.Controllers
{
    public partial class AdminController : AuthBaseController
    {


        public ActionResult PermissionList()
        {               
            ViewData["PermissionList"] = PermissionMenu.FindWithAll(); 
            return View();
        }


        public ActionResult PermissionView()
        {
            long id = Request["id"].ToLong(); 
           
            ViewData["Permission"] = PermissionMenu.FindById(id); ;

            return View();
        }

        [HttpPost]
        public ActionResult PermissionAction(PermissionMenu model)
        {

            if (model.Name.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入名称！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (model.Url.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入权限值！"
                }, JsonRequestBehavior.AllowGet);
            }

            var rbool = model.Save();
            if (!rbool)
            {               
                    return Json(new
                    {
                        success = false,
                        message = "系统异常,请稍后重试！"
                    }, JsonRequestBehavior.AllowGet);
              
            }
            return Json(new
            {
                success = true,
                message = "操作成功！"
            }, JsonRequestBehavior.AllowGet);
        }
       



    }
    

}
