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
using MSNet.Common;

namespace MSNet.WebAdmin.Controllers
{
    public class PicturesController : AuthBaseController
    {

        public ActionResult List()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 10
            };
            string keyword = null;
            if (!Request["keyword"].IsNullOrEmpty())
            {
                keyword = Request["keyword"];
            }

            int year = 0;
            if (Request["year"].ToInt(0) > 0)
            {
                year = Request["year"].ToInt(0);
            }
            int month = 0;
            if (Request["month"].ToInt(0) > 0)
            {
                month = Request["month"].ToInt(0);
            }
            int day = 0;
            if (Request["day"].ToInt(0) > 0)
            {
                day = Request["day"].ToInt(0);
            }

            IList<PicturesCategory> list = PicturesCategory.FindWithPage(keyword, year, month, day, page);

            PagedList<PicturesCategory> plist = null;
            if (list != null)
            {

                plist = new PagedList<PicturesCategory>(list.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["PictureList"] = plist;

            //ViewData["PictureList"] = Pictures.FindByCategoryId(1);

            return View();
        }
        public ActionResult PictureView()
        {
            long id = Request["id"].ToLong();
            ViewData["PictureCategory"] = PicturesCategory.FindById(id);
            ViewData["Pictures"] = Pictures.FindByCategoryId(id);
            return View();
        }


        public ActionResult PictureAction(PicturesCategory model)
        {

            if (model.Name.IsNullOrEmpty())
            {
                return JsonFail("请输入标题！");
            }
            if (model.PublicDate==null)
            {
                return JsonFail("请选择日期！");
            }
            var actionStr = "添加图片";
            if (model.CategoryId > 0)
            {
                actionStr = "修改图片";
                model.PersistentState = PersistentState.Persistent;
            }
            var rbool = model.Save();
            //WebAppLogsWrite(this.CurrentUser.PassportId, this.CurrentUser.UserName, actionStr, model.Name); // 写入日志 
            if (rbool)
            {
                return JsonSuccess("操作成功！");
            }
            return JsonFail("系统异常,请稍后重试！");
        }

        //[HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase file)
        {
            //保存到临时文件夹  
            string urlPath = "/upload/images";
            string filePathName = string.Empty;

            string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "upload/images");
            if (Request.Files.Count == 0)
            {
                return Json(new { status = 0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }

            string ex = Path.GetExtension(file.FileName);
            filePathName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ex; //Guid.NewGuid().ToString("N") + ex;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(Path.Combine(localPath, filePathName));

            return Json(new
            {
                status = 0,
                filePath = filePathName
            });

        }
        
    }
}
