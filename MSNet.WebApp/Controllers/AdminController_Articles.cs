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
using MSNet.Common.Articles;
namespace MSNet.WebApp.Controllers
{
    public partial class AdminController : AuthBaseController
    {    
        #region 新闻
        public ActionResult ArticlesList()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 20
            };
            var Title = "";
            if (!Request["Title"].IsNullOrEmpty())
            {
                Title = Request["Title"];
            }
            long CategoryId = 0;
            if (Request["CategoryId"].ToLong() > 0)
            {
                CategoryId = Request["CategoryId"].ToLong();
            }

            IList<Articles> nlist = null;
            if (Title.IsNullOrEmpty() && CategoryId==0)
            {
                nlist = Articles.FindWithPage(page);
            }
            if (Title.IsNullOrEmpty() && CategoryId > 0)
            {
                nlist = Articles.FindWithPage(page);
            }
            if (!Title.IsNullOrEmpty() && CategoryId == 0)
            {
                nlist = Articles.FindWithPage(page);
            }
            if (!Title.IsNullOrEmpty() && CategoryId > 0)
            {
                nlist = Articles.FindWithPage(page);
            }
            PagedList<Articles> plist = null;
            if (nlist != null) {
                plist = new PagedList<Articles>(nlist.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }
            ViewData["ArticlesList"] = plist;
          
            ViewData["CategoryList"] = ArticlesCategory.FindWithAll();      

            return View();
        }
        public ActionResult ArticlesView()
        {

            ViewData["CategoryList"] = ArticlesCategory.FindWithAll();     
            var ArticlesId = Request["aid"].ToLong();
            Articles articles =  Articles.FindById(ArticlesId);
            if (articles == null)
            {
                articles = new Articles
                {
                    ArticleId = 0,
                    CreatedTime = DateTime.Now,
                    LastModifiedTime = DateTime.Now                  
                };
            }
            ViewData["Articles"] = articles;
            return View();
        }      
        #endregion

        #region 新闻增删改
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ArticlesAction(Articles model)
        {            

            if (model.CategoryId == 0)
            {
                return Json(new
                {
                    success = false,
                    message = "请选择所属栏目！"
                }, JsonRequestBehavior.AllowGet);
            }
          
            if (model.Title.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入标题！"
                }, JsonRequestBehavior.AllowGet);
            }
            string PictureUrl = Request["PictureUrl"];

            if (model.Contents.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入内容！"
                }, JsonRequestBehavior.AllowGet);
            }


            bool r = false;
            var _n = Articles.FindById(model.ArticleId);
            if (_n != null)
            {
                _n.CategoryId = model.CategoryId;
                _n.Title = model.Title;
                _n.Editor = model.Editor;
                _n.Media = model.Media;
                _n.Description = model.Description;
                _n.Contents = model.Contents;
                _n.IsTop = model.IsTop;
                _n.LastModifiedTime = DateTime.Now;
                r = _n.Save();
            }
            else
            {                
                r = model.Save();
            }
            if (r)
            {
                return Json(new
                {
                    success = true,
                    message = "操作成功！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = false,
                message = "操作失败，请重试！"
            }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult DelArticles()
        {
            var ids = Request["ids"].Trim(',').Split(',').ToList().ToLongList();
            var r = true;
            foreach (var item in ids)
            {
                var rbool = new Articles { ArticleId = item }.Remove();
                r = r & rbool;
            }
            if (!r)
            {
                return Json(new
                {
                    success = false,
                    message = "删除失败！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = true,
                message = "删除成功！"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TopArticles()
        {
            var ArticlesId = Request["aid"].ToLong();
            if (ArticlesId <1)
            {
                return Json(new
                {
                    success = false,
                    message = "参数错误！"
                }, JsonRequestBehavior.AllowGet);
            }
            var _n = Articles.FindById(ArticlesId);
            if (_n == null)
            {
                return Json(new
                {
                    success = false,
                    message = "参数错误！"
                }, JsonRequestBehavior.AllowGet);
            }
            _n.IsTop = Math.Abs(_n.IsTop - 1);
            var r = _n.Save();
            if (r)
            {
                return Json(new
                {
                    success = true,
                    message = "修改成功！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = false,
                message = "修改失败，请重试！"
            }, JsonRequestBehavior.AllowGet);

        }
      
        #endregion 
    }
    

}
