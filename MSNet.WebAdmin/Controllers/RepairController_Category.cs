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
using MSNet.Repair;


namespace MSNet.WebAdmin.Controllers
{
    public partial class RepairController : AuthBaseController
    {      

        public ActionResult Categorys()
        {
            long pId = Request["parentId"].ToLong();
            IList<RepairCategory> list =  RepairCategory.FindWithAll(); 
            IList<RepairCategory> plist = new List<RepairCategory>();          
            if (pId > 0)
            {
                if(list.Where(q => q.ParentId.Equals(pId)).Count()>0)
                {
                    plist = list.Where(q => q.ParentId.Equals(pId)).ToList();
                    foreach (var o in plist)
                    {
                        var oo = list.Where(p => p.CategoryId.Equals(o.ParentId)).FirstOrDefault();
                        o.ParentName = ((oo != null) ? oo.Name : "无");
                    }
                }              
            }
            else 
            {
                plist = list.Where(q => q.ParentId.Equals(0)).ToList();
            }

            ViewData["Breads"] = RepairCategory.GetBreadList(pId, list);
            ViewData["Categorys"] = plist;
            return View();
        }

        public ActionResult CategoryView()
        {
            long id = Request["id"].ToLong();
            ViewData["Category"] = RepairCategory.FindById(id);
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAction(RepairCategory model)
        {

            if (model.Name.IsNullOrEmpty())
            {
                return JsonFail("请输入类别名称！");
            }
            var actionStr = "添加报修类别";
            if (model.CategoryId > 0)
            {
                actionStr = "修改报修类别";
                model.PersistentState = PersistentState.Persistent;
            }
            var rbool = model.Save();
            WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, actionStr, model.Name); // 写入日志 

            if (rbool)
            {
                return JsonSuccess("操作成功！");
            }
            return JsonFail("系统异常,请稍后重试！");

        }

        [HttpPost]
        public ActionResult CategoryRemove()
        {
            var id = Request["categoryId"].ToLong();

            if (id > 0)
            {
                RepairCategory item = RepairCategory.FindById(id);
                if (item == null)
                {
                    return JsonFail("参数错误");
                }
                var rbool = item.Remove();
                WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, "删除报修类别", item.Name); // 写入日志 
                if (rbool)
                {                    
                    return JsonSuccess("操作成功！");
                }
            }
            return JsonFail("删除失败！");

        }
      
       
    }
}
