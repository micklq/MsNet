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
namespace MSNet.WebAdmin.Controllers
{
    public partial class AdminController : AuthBaseController
    {       

        public ActionResult PermissionList()
        {
            ViewData["Permissions"] =  Permissions.FindWithAll(); 
            return View();
        }

        public ActionResult PermissionView()
        {
            long id = Request["id"].ToLong();
            ViewData["PermissionRoot"] = Permissions.FindRoot(); 
            ViewData["Permission"] = Permissions.FindById(id);            
            return View();
        }

        [HttpPost]
        public ActionResult PermissionAction(Permissions model)
        {

            if (model.Name.IsNullOrEmpty())
            {
                return JsonFail("请输入菜单名称！");               
            }
            var actionStr = "添加菜单";
            if (model.PermissionId > 0) {
                actionStr = "维护菜单";
                model.PersistentState = PersistentState.Persistent;
            }         
            var rbool = model.Save();
            WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, actionStr, model.Name); // 写入日志 
            if (rbool)
            {
                return JsonSuccess("操作成功！");  
            }
            return JsonFail("系统异常,请稍后重试！");                     
            
        }


        [HttpPost]
        public ActionResult PermissionRemove()
        {
            var id = Request["permissionId"].ToLong();

            if (id > 0)
            {
                Permissions item = Permissions.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除菜单", item.Name); // 写入日志 
                if (rbool)
                {
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }
    }
}
