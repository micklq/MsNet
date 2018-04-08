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
        //
        // GET: /Admin/

        public ActionResult AdminList()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 10
            };
            var keyword = "";
            if (!Request["uname"].IsNullOrEmpty())
            {
                keyword = Request["uname"];
            }
            var exceptIds = new List<long> { this.CurrentUser.PassportId };
            IList<UserPassport> ulist = UserPassport.FindWithAdminPage(keyword, exceptIds, page); //排除自己;

            PagedList<UserPassport> plist = null;
            if (ulist != null)
            {
                plist = new PagedList<UserPassport>(ulist.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["AdminList"] = plist;
            return View();
        }

        public ActionResult AdminView()
        {
            long id = Request["id"].ToLong();
            ViewData["UserRole"] = Role.FindWithAll();
            ViewData["UserPassport"] = UserPassport.FindById(id);
            return View();
        }

        [HttpPost]
        public ActionResult AdminAction(UserPassport model)
        {
            if (model.UserName.IsNullOrEmpty())
            {
                return JsonFail("请输入用户名！"); 
            }
            if (model.PassportId < 1)
            {
                if (model.Password.IsNullOrEmpty())
                {
                    return JsonFail("请输入密码！");
                }
                UserPassport uPassport = null;
                model.RoleType = UserRoleType.Adminstrator;
                var result = MemberShip.Add(model, GetSignedUpInfo(), out uPassport);
                WebAppLogsWrite(this.CurrentUser.PassportId,this.CurrentUser.UserName,"添加管理员",result.message.IsNullOrEmpty()?"添加成功":result.message); // 写入日志            
                if (!result.success)
                {
                    return JsonFail(result.message);
                }   
            }
            else 
            {
                var result = MemberShip.Update(model, GetSignedUpInfo());
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "更新管理员", result.message.IsNullOrEmpty() ? "更新成功" : result.message); // 写入日志 
                if (!result.success)
                {
                    return JsonFail(result.message);
                }               
            }
            return JsonSuccess("操作成功！");
        }


        public ActionResult ModifyPasswordView()
        {
            long id = Request["id"].ToLong();
            ViewData["UserPassport"] = UserPassport.FindById(id);
            return View();
        }

        [HttpPost]
        public ActionResult ModifyCurrUserPassword()
        {
            long passportId = this.CurrentUser.PassportId;
            string oPassword = Request["oPassword"].ToString(),
                nPasspword = Request["nPasspword"].ToString();
            if (passportId < 1)
            {
                return JsonFail("参数错误！"); 
            }
            if (oPassword.IsNullOrEmpty())
            {
                return JsonFail("请输入旧密码！");               
            }
            if (nPasspword.IsNullOrEmpty())
            {
                return JsonFail("请输入新密码！");  
            }
            var result = MemberShip.ModifyPassword(passportId, oPassword, nPasspword);           
            WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "更新密码", result.message); // 写入日志 
            if (!result.success)
            {               
                return JsonFail(result.message);                  
            }            
            return JsonSuccess("操作成功！");           

        }


    }
}
