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
    public class ProductsController : AuthBaseController
    {


        public ActionResult Brand()
        {          
           
            return View();
        }

        public ActionResult Category()
        {

            return View();
        }

        public ActionResult List()
        {

            return View();
        }

        public ActionResult Add()
        {
           //var Id = Request["id"].ToInt();
           //var news = Articles.FindById(Id);
           //ViewData["News"] = news ?? new Articles();
          return View();
        }
    }
}
