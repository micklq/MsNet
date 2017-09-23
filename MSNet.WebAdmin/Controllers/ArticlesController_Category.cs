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
    public partial class ArticlesController : AuthBaseController
    {

        public ActionResult Categorys()
        {
            ViewData["Categorys"] = ArticlesCategory.FindWithAll(); 
            return View();
        }
        public ActionResult CategoryView()
        {
            long id = Request["id"].ToLong();
            ViewData["Category"] = ArticlesCategory.FindById(id);    
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAction(ArticlesCategory model)
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
        public ActionResult CategoryRemove()
        {
            var id = Request["categoryId"].ToLong();

            if (id > 0) {
                ArticlesCategory item = ArticlesCategory.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }
                var rbool = item.Remove();              
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除资讯栏目", item.Name); // 写入日志 
                if(rbool){
                    Articles.UpdateCategoryId(item.CategoryId, 0);//更新资讯栏目为0
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");           
           
        }


    }
}
