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
    public partial class SystemController : AuthBaseController
    {   

        public ActionResult Logs()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 20
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

        public ActionResult LogsView()
        {
            long id = Request["id"].ToLong();            
            ViewData["WebAppLogs"] = WebAppLogs.FindById(id);
            return View();
        }

        [HttpPost]
        public ActionResult LogRemove()
        {
            var id = Request["logId"].ToLong();

            if (id > 0)
            {                
                var rbool = new WebAppLogs() { Id = id }.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除日志", "删除日志"); // 写入日志 
                if (rbool)
                {                 
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }

        [HttpPost]
        public ActionResult BatchRemove()        {

            var logsIds = Request["logIds"].Trim(',');
            if (logsIds.IsNullOrEmpty())
            {
                return JsonFail("请选择删除的日志！");
            }
            var list = logsIds.Split(',').ToList();
            var rbool = false;
            if (list.Count > 0)
            {
               rbool = true;
               foreach (var o in list)
               {                       
                  rbool = rbool && (new WebAppLogs() { Id = o.ToLong() }.Remove());                        
               }
               WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "批量删除日志", "批量删除日志"); // 写入日志 
            }            
            if (rbool)
            {
                return JsonSuccess("操作成功！");
            }
            return JsonFail("系统异常,请稍后重试！");

        }
      
    }
}
