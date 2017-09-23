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
    public  partial class SystemController : AuthBaseController
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
         
      
    }
}
