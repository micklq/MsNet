using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Web;
using MSNet.Common.Util;
using MSNet.Common.Web.Pager;
using MSNet.Common;
using MSNet.Joined;

namespace MSNet.WebAdmin.Controllers
{
    public partial class JoinedController : AuthBaseController
    {       
        

        public ActionResult List()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 10
            };
            string keyword = null;
            if (!Request["keyword"].IsNullOrEmpty())
            {
                keyword = Request["keyword"];
            }

            IList<JoinedArticles> list = JoinedArticles.FindWithPage(keyword, page);

            PagedList<JoinedArticles> plist = null;
            if (list != null)
            {
                plist = new PagedList<JoinedArticles>(list.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["ArticleList"] = plist;
           
           
            return View();
        }
        public ActionResult ArticleView()
        {
            long id = Request["id"].ToLong();
            ViewData["Article"] = JoinedArticles.FindById(id);           
            return View();
        }


        public ActionResult ArticleAction(JoinedArticles model)
        {

            if (model.Title.IsNullOrEmpty())
            {
                return JsonFail("请输入资讯标题！");
            }
            if (model.Contents.IsNullOrEmpty())
            {
                return JsonFail("请输入资讯内容！");
            }
            var actionStr = "添加加盟资讯";
            if (model.ArticleId > 0)
            {
                actionStr = "修改加盟资讯";
                model.PersistentState = PersistentState.Persistent;
            }
            var rbool = model.Save();
            WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, actionStr, model.Title); // 写入日志 
            if (rbool)
            {
                return JsonSuccess("操作成功！");
            }
            return JsonFail("系统异常,请稍后重试！");  
        }

        [HttpPost]
        public ActionResult ArticleRemove()
        {
            var id = Request["articleId"].ToLong();
            if (id > 0)
            {
               Articles item =  Articles.FindById(id);
               if (item == null)
               {
                   return JsonFail("参数错误");
               }
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除加盟资讯", item.Title); // 写入日志 
                if (rbool)
                {
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }
    }
}
