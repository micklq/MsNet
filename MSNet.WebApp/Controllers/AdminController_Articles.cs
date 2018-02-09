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

        public ActionResult ArticlesList()
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

            long categoryId = 0;
            if (!Request["CategoryId"].IsNullOrEmpty() && Request["CategoryId"].ToLong(0) > 0)
            {
                categoryId = Request["CategoryId"].ToLong(0);
            }

            IList<Articles> list = Articles.FindWithPage(keyword, categoryId, page);

            PagedList<Articles> plist = null;
            if (list != null)
            {

                plist = new PagedList<Articles>(list.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["ArticlesList"] = plist;

            ViewData["ArticlesCategoryList"] = ArticlesCategory.FindWithAll(); 


            return View();
        }
        public ActionResult ArticlesView()
        {
            long id = Request["id"].ToLong();
            ViewData["Articles"] = Articles.FindById(id);
            ViewData["ArticlesCategoryList"] = ArticlesCategory.FindWithAll(); 
            return View();
        }
       

        [HttpPost]
        public ActionResult ArticlesAction(Articles model)
        {
            if (model.Title.IsNullOrEmpty())
            {
                return JsonFail("请输入资讯标题！");
            }
            if (model.Contents.IsNullOrEmpty())
            {
                return JsonFail("请输入资讯内容！");
            }
            var actionStr = "添加资讯";
            if (model.ArticleId > 0)
            {
                actionStr = "修改资讯";
                model.PersistentState = PersistentState.Persistent;
            }           
            if (!model.ImageUrl.IsNullOrEmpty() && !model.ImageUrl.Contains("upload/images"))
            {
                DateTime dt = DateTime.Now;
                string iUrl = String.Format("/upload/images/{0}/{1}/{2}/{3}", dt.Year, String.Format("{0:00}", dt.Month), String.Format("{0:00}", dt.Day), model.ImageUrl);
                model.ImageUrl = iUrl;
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
        public ActionResult ArticlesRemove()
        {
            var id = Request["articleId"].ToLong();
            if (id > 0)
            {
                Articles item = Articles.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除资讯", item.Title); // 写入日志 
                if (rbool)
                {
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }
        
    }
}
