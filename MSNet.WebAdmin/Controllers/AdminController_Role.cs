using System;
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
using MSNet.Common.Passports;
namespace MSNet.WebAdmin.Controllers
{
    public partial class AdminController : Controller //AuthBaseController
    {       

        public ActionResult Roles()
        {
            ViewData["Roles"] = Role.FindWithAll(); 
            return View();
        }
        public ActionResult RoleView()
        {
            long id = Request["id"].ToLong();
            ViewData["Permissions"] = Permission.FindWithAll();
            ViewData["RolePermission"] = RolePermission.FindByRoleId(id);
            ViewData["Role"] = Role.FindById(id);    
            return View();
        }

        [HttpPost]
        public ActionResult RoleAction(Role model)
        {

            var permissionLevel = Request["PermissionLevel"].Trim(',').Split(',').ToList();
            if (model.Name.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入名称！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (model.RoleId > 0)
            {
                model.PersistentState = PersistentState.Persistent;
            }    
            var rbool = model.Save();
            if (rbool)   //添加权限
            {
                if (permissionLevel.Count > 0)
                {
                    RolePermission.RemoveByRoleId(model.RoleId);
                    foreach (var o in permissionLevel)
                    {
                        var oo = o.Trim('-').Split('-').ToList().ToLongList(false); 
                        if (oo.Count == 3)
                        {
                            rbool = rbool && new RolePermission() { RoleId = model.RoleId, ParentPermId = oo[0], PermissionId = oo[1], PermissionLevel = oo[2] }.Save();
                        }
                    }
                }                                
            }
            if (rbool)
            {
                return Json(new
                {
                    success = true,
                    message = "添加成功！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = false,
                message = "系统异常,请稍后重试！"
            }, JsonRequestBehavior.AllowGet);

        }

    }
}
