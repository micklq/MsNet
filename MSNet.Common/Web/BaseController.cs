using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using MSNet.Common.Util;
using MSNet.Common.Security;

namespace MSNet.Common.Web
{
    public class BaseController : Controller
    {

        public  JsonResult JsonSuccess(String message = "")
        {
            return Json(AjaxResult.Success(message), JsonRequestBehavior.AllowGet);  
        }

        public JsonResult JsonFail(String message)
        {
            return Json(AjaxResult.Fail(message), JsonRequestBehavior.AllowGet);             
        }
       
        public SignedUpInfo GetSignedUpInfo()
        {
            SignedUpInfo  info = new SignedUpInfo();
            info.SignedUpIp = HttpContext.Request.ServerVariables.Get("Remote_Addr");
            info.HttpReferer = HttpContext.Request.ServerVariables.Get("Http_Referer");
            info.HttpUserAgent = HttpContext.Request.ServerVariables.Get("Http_User_Agent");            
            info.RefererDomain = HttpContext.Request.ServerVariables.Get("Http_Host");
            info.UtmSource = HttpContext.Request.Params["UtmSource"];
            info.InviteCode = HttpContext.Request.Params["InviteCode"];
            return info;
        }

        public void WebAppLogsWrite(long passportId, string userName, string userAction, string messages)
        {
            WebAppLogs logs = new WebAppLogs();
            logs.ClientIp = HttpContext.Request.ServerVariables.Get("Remote_Addr");
            logs.HttpReferer = HttpContext.Request.ServerVariables.Get("Http_Referer");
            logs.HttpUserAgent = HttpContext.Request.ServerVariables.Get("Http_User_Agent");
            logs.RefererDomain = HttpContext.Request.ServerVariables.Get("Http_Host");
            logs.PassportId = passportId;
            logs.UserName = userName;
            logs.UserAction = userAction;
            logs.Messages = messages;
            logs.Insert();
        }

        public string Upload(int maxLength, string path, IList<string> fileExt, string fileName = "")
        {            
            var UploadPath = path;
            if (fileName.IsNullOrEmpty())
            {
                fileName = Request["fName"];
                if (fileName.IsNullOrEmpty())
                {
                    fileName = "UploadFile";
                }
            }
            //上传和返回(保存到数据库中)的路径            
            string savePath = string.Empty;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase postFile = Request.Files[fileName];
                if (postFile != null)
                {
                    if (postFile.ContentLength > maxLength * 1024 * 1024)
                    {
                        return "{\"success\":false,\"message\":\"请把文件大小请限制在" + maxLength + "M以内！\"}";

                    }
                    string strPath = postFile.FileName;
                    string type = strPath.Substring(strPath.LastIndexOf(".") + 1).ToLower();
                    if (!fileExt.Contains(type))
                    {
                        return "{\"success\":false,\"message\":\"上传文件格式不正确！\"}";
                    }
                    //创建新的名称
                    string newName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    savePath = newName + "." + type;
                    string uploadPath = Server.MapPath("~" + path);
                    uploadPath += newName + "." + type;
                    var httpUrl = path + newName + "." + type;
                    //保存文件
                    postFile.SaveAs(uploadPath);
                    try
                    {
                        //压缩文件 
                        if (type == "pdf")
                        {
                            ZipFile.BZipFile(uploadPath, uploadPath + ".zip");
                        }
                    }
                    catch
                    {
                    }


                    return "{\"success\":true,\"message\":\"" + httpUrl + "\"}";
                }
            }
            return "{\"success\":false,\"message\":\"上传失败！\"}";

        }
        public string UpLoadImage()
        {
            var maxLen = 2;
            var path = "/Content/Upload/Image/";
            var ext = new List<string>() { "jpg", "gif", "png" };
            string fileName = Request["fName"];
            if (fileName.IsNullOrEmpty())
            {
                fileName = "UploadFile";
            }
            return Upload(maxLen, path, ext, fileName);
        }
        public string UploadDoc()
        {
            var maxLen = 150;
            var path = "/Content/Upload/Doc/";
            var ext = new List<string>() { "doc", "docx", "pdf" };
            string fileName = Request["fName"];
            if (fileName.IsNullOrEmpty())
            {
                fileName = "UploadFile";
            }
            return Upload(maxLen, path, ext, fileName);
        }

         

    }
}
