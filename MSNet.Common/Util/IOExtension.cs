using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using M2SA.AppGenome;
using M2SA.AppGenome.Logging;
namespace MSNet.Common.Util
{
    public static class IOExtension
    {
        public static string GetPath(this string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("~/", "");
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 合并url
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static string CombineUrl(this string u1, string u2)
        {
            if (u1.IsNullOrEmpty() && u2.IsNullOrEmpty())
                return "";
            if (u1.IsNullOrEmpty() || u2.IsNullOrEmpty())
                return "{0}{1}".FormatString(u1, u2);
            u1 = u1.TrimEnd('/');
            u2 = u2.TrimStart('/');
            return ToUrlPath(Path.Combine(u1, u2));
        }

        /// <summary>
        /// 合并unc
        /// 如将 "C:\Windows" 和 "Microsoft.NET\Framework\v2.0.50727"
        /// 合并为 "C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727"
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static string CombineUnc(this string u1, string u2)
        {
            if (u1.IsNullOrEmpty() && u2.IsNullOrEmpty())
                return "";
            if (u1.IsNullOrEmpty() || u2.IsNullOrEmpty())
                return "{0}{1}".FormatString(u1, u2);
            u1 = u1.TrimEnd('\\');
            u2 = u2.TrimStart('\\');
            return ToUncPath(Path.Combine(u1, u2));
        }

        /// <summary>
        /// 将"\"转为"/"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToUrlPath(this string path)
        {
            return path.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        /// <summary>
        /// 将"/"转为"\"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToUncPath(this string path)
        {
            return path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }
        
        #region IO目录操作
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool CreateDirectory(this string dirPath)
        {
            try
            {
                bool rBool = false;
                if (!DirectoryExists(Path.GetDirectoryName(dirPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dirPath));
                    rBool = true;
                }
                return rBool;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("IOException").Error(ex, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dirPath">目录路径</param>
        /// <returns></returns>
        public static bool DeleteDirectory(this string dirPath)
        {
            try
            {
                bool rBool = false;
                if (DirectoryExists(dirPath))
                {
                    Directory.Delete(dirPath);
                    rBool = true;
                }
                return rBool;
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("IOException").Error(ex, ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 检测目录是否存在
        /// </summary>
        /// <param name="dirPath">文件目录</param>
        /// <returns></returns>
        public static bool DirectoryExists(this string dirPath)
        {
            return Directory.Exists(dirPath);
        }
        #endregion                
    }
}
