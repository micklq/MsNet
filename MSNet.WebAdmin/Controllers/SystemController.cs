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

            return View();
        }     
      
    }
}
