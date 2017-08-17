﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Web;
using MSNet.Common.Util;
using MSNet.Common.Web.Pager;
using MSNet.Common;
namespace MSNet.WebAdmin.Controllers
{
    public partial class AdminController : Controller
    {       

        public ActionResult Permissions()
        {
            ViewData["Permissions"] = PermissionMenu.FindWithAll(); 
            return View();
        }

        public ActionResult PermissionView()
        {
            long id = Request["id"].ToLong();
            ViewData["PermissionRoot"] = PermissionMenu.FindRoot(); 
            ViewData["Permission"] = PermissionMenu.FindById(id);            
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
            if (model.PermissionId > 0) {
                model.PersistentState = PersistentState.Persistent;
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