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
    public class SystemController : AuthBaseController
    {    
        public ActionResult Base()
        {          
           
            return View();
        }

        public ActionResult Category()
        {

            return View();
        }

        public ActionResult Data()
        {

            return View();
        }

        public ActionResult Shielding()
        {

            return View();
        }

        public ActionResult Logs()
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
            string beginTime = null;
            if (!Request["beginTime"].IsNullOrEmpty())
            {
                beginTime = Request["beginTime"];
            }
            string endTime = null;
            if (!Request["endTime"].IsNullOrEmpty())
            {
                endTime = Request["endTime"];
            }

            IList<WebAppLogs> list = WebAppLogs.FindWithPage(keyword, beginTime, endTime, page);

            PagedList<WebAppLogs> plist = null;
            if (list != null)
            {
                plist = new PagedList<WebAppLogs>(list.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["LogsList"] = plist;
            return View();
        }     
      
    }
}
