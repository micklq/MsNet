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
namespace MSNet.WebApp.Controllers
{
    public partial class AdminController : AuthBaseController
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {   
            return View();
        }
               
       

    }
}
