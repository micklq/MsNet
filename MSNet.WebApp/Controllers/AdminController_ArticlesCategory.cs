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

        public ActionResult ArticlesCategoryList()
        {
            ViewData["CategoryList"] = ArticlesCategory.FindWithAll();
            return View();
           
        }

        public ActionResult ArticlesCategoryView()
        {
            long id = Request["id"].ToLong();

            ViewData["ArticlesCategory"] = ArticlesCategory.FindById(id);           
            return View();
        }

        [HttpPost]
        public ActionResult ArticlesCategoryAction(ArticlesCategory model)
        {

            if (model.Name.IsNullOrEmpty())
            {
                return JsonFail("请输入栏目名称！"); 
            }
            var actionStr = "添加资讯栏目";
            if (model.CategoryId > 0)
            {
                actionStr = "修改资讯栏目";
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
        public ActionResult ArticlesCategoryRemove()
        {
            var id = Request["categoryId"].ToLong();

            if (id > 0)
            {
                ArticlesCategory item = ArticlesCategory.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }               
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除资讯栏目", item.Name); // 写入日志 
                if (rbool)
                {
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }
     
        
    }
}
