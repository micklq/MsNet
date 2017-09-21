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
        //
        // GET: /Admin/

        public ActionResult List()
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
            ViewData["UserRole"] = UserRole.FindWithAll();
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
                UserPassport status = null;
                model.RoleType = UserRoleType.Adminstrator;
                var result = MemberShip.Add(model, GetSignedUpInfo(), out status);
                if (!result.success)
                {
                    return JsonFail(result.message);
                }   
            }
            else 
            {
                var result = MemberShip.Update(model, GetSignedUpInfo());
                if (!result.success)
                {
                    return JsonFail(result.message);
                }               
            }
            return JsonSuccess("操作成功！");
        }


        public ActionResult ModifyPswView()
        {
            long id = Request["id"].ToLong();
            ViewData["UserPassport"] = UserPassport.FindById(id);
            return View();
        }

        [HttpPost]
        public ActionResult ModifyCurrUserPsw()
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
            if (!result.success)
            {
                return JsonFail(result.message);                  
            }
            return JsonSuccess("操作成功！");           

        }


    }
}
