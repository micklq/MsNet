using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Util;
using MSNet.Common.Web.Pager;
namespace MSNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {    
            return View();           
        }

        public ActionResult Welcome()
        {
            return View();
        }

    }
}
