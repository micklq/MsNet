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
using MSNet.Common;
namespace MSNet.WebApp.Controllers
{
    public partial class AdminController : AuthBaseController
    {       

        public ActionResult RoleList()
        {
            ViewData["Roles"] = Role.FindWithAll(); 
            return View();
        }
        public ActionResult RoleView()
        {
            long id = Request["id"].ToLong();
            ViewData["Permissions"] = Permissions.FindWithAll();
            ViewData["RolePermission"] = RolePermission.FindByRoleId(id);
            ViewData["Role"] = Role.FindById(id);    
            return View();
        }

        [HttpPost]
        public ActionResult RoleAction(Role model)
        {

            var permissionValues = Request["PermissionValue"].Trim(',').Split(',').ToList();
            if (model.Name.IsNullOrEmpty())
            {
                return JsonFail("请输入角色名称！");                
            }
            var actionStr = "添加角色";
            if (model.RoleId > 0)
            {
                actionStr = "维护角色";
                model.PersistentState = PersistentState.Persistent;
            }    
            var rbool = model.Save();
            WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, actionStr, model.Name); // 写入日志 
            if (rbool)   //添加权限
            {
                if (permissionValues.Count > 0)
                {
                    RolePermission.RemoveByRoleId(model.RoleId);
                    foreach (var o in permissionValues)
                    {
                        var oo = o.Trim('-').Split('-').ToList().ToLongList(false); 
                        if (oo.Count == 3)
                        {
                            RolePermission rolePermissoin = new RolePermission{ RoleId = model.RoleId, ParentPermissionId = oo[0], PermissionId = oo[1], PermissionValue = oo[2] };
                            rbool = rbool && rolePermissoin.Insert();
                        }
                    }
                }                                
            }
            if (rbool)
            {
                return JsonSuccess("操作成功！");               
            }
            return JsonFail("系统异常,请稍后重试！");

        }

        [HttpPost]
        public ActionResult RoleRemove()
        {
            var id = Request["roleId"].ToLong();

            if (id > 0) {
                Role item = Role.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除角色", item.Name); // 写入日志 
                if(rbool){
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");           
           
        }


    }
}
