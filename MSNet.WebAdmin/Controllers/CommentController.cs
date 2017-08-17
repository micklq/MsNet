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

namespace MSNet.WebAdmin.Controllers
{
    public class CommentController : AuthBaseController
    {    
        public ActionResult List()
        {          
           
            return View();
        }
      
    }
}
