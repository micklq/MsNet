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

namespace MSNet.WebAdmin.Controllers
{
    public class FeedbackController : AuthBaseController
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


            IList<Feedback> list = Feedback.FindWithPage(keyword, page);

            PagedList<Feedback> plist = null;
            if (list != null)
            {
                plist = new PagedList<Feedback>(list.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["FeedbackList"] = plist;

            return View();
           
        }
      
    }
}
