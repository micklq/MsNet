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
    public partial class RepairController : AuthBaseController
    {


        public ActionResult Orders()
        {
           
            return View();
        }        

        public ActionResult List()
        {

            return View();
        }
       
    }
}
