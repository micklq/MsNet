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
using MSNet.Common.DataRepositories;
namespace MSNet.WebAdmin.Controllers
{
    public class HomeController : AuthBaseController
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
