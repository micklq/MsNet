using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;

using MSNet.Common;
using MSNet.Common.Web;
using MSNet.Common.Util;
using MSNet.Common.Articles;

namespace MSNet.WebApp.Controllers
{
    public class ArticlesController : Controller
    {        //
        // GET: /News/

        public ActionResult Index()
        {          
            ViewData["TopList"] = Articles.FindWithPage(new Pagination
            {
                PageIndex = 1,
                PageSize = 5
            });
            ViewData["NewsList"] = Articles.FindWithPage(new Pagination
            {
                PageIndex = 1,
                PageSize = 12
            });
            return View();
        }
        public ActionResult Show()
        {
           var Id = Request["id"].ToInt();
           var news = Articles.FindById(Id);
           ViewData["News"] = news ?? new Articles();
          return View();
        }
    }
}
