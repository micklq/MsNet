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

       

        public ActionResult RoleList()
        {   
            ViewData["RoleList"] = Role.FindWithAll(); 
            return View();
        }

        public ActionResult RoleView()
        {
            long id = Request["id"].ToLong();          
            ViewData["Role"] = Role.FindById(id); 
            ViewData["RolePermission"] =  RolePermission.FindByRoleId(id);  
            ViewData["Permission"] = Permission.FindWithAll();
                
            return View();
            
        }
       
        [HttpPost]
        public ActionResult RoleAction(Role model)
        {

            var rolePermissions = model.RolePermissions.Trim(',').Split(',').ToList();
            if (model.Name.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入名称！"
                }, JsonRequestBehavior.AllowGet);
            }          

            var rbool = model.Save();            
            if (rbool)   //添加权限
            {
                if (rolePermissions.Count > 0) {
                    RolePermission.RemoveByRoleId(model.RoleId);
                    foreach (var o in rolePermissions)
                    {
                        var oo = o.Trim('_').Split('_').ToList().ToLongList();
                        if (oo.Count == 2)
                        {
                            rbool = rbool && new RolePermission() { RoleId = model.RoleId, PermissionId = oo[0], PermissionLevel = "" }.Save();
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
