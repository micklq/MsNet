using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using M2SA.AppGenome.Data.SqlMap;
namespace MSNet.Common.Util
{
    public static class StringExtension
    {
        
        public static int RealLength(this string source)
        {
            if (source.IsNullOrEmpty())
                return 0;
            return Encoding.Default.GetByteCount(source);
        }
        public static string Sub(this string source, int len, bool needEndDot = false)
        {
            if (source.IsNullOrEmpty())
                return "";
            if (source.RealLength() <= len)
                return source;

            string str = string.Empty;
            int num = 0;
            char[] chArray = source.ToCharArray();

            foreach (var c in chArray)
            {
                str += c;

                num += c > '\x007f' ? 2 : 1;

                if (num >= len)
                    break;
            }

            if (needEndDot)
            {
                str = str + "...";
            }
            return str;
        }
        public static string UrlEncode(this string str)
        {
            return str.UrlEncode(Encoding.UTF8);
        }
        public static string UrlEncode(this string str, Encoding encode)
        {
            if (str.IsNullOrEmpty())
                return "";

            return HttpUtility.UrlEncode(str, encode);
        }

        public static string UrlDecode(this string str)
        {
            return str.UrlDecode(Encoding.UTF8);
        }
        public static string UrlDecode(this string str, Encoding encode)
        {
            if (str.IsNullOrEmpty())
                return "";

            return HttpUtility.UrlDecode(str, encode);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static string FormatString(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        /// <summary>
        /// 忽略大小写文本比对
        /// </summary>
        /// <param name="str"></param>
        /// <param name="compareString"></param>
        /// <returns></returns>
        public static bool IsEquals(this string str, string compareString)
        {
            return str.IsEquals(compareString, true);
        }

        public static bool IsEquals(this string str, string compareString, bool ignoreCase)
        {
            if (str == compareString)
                return true;

            return string.Compare(str, compareString, ignoreCase) == 0;
        }
        public static Guid ToGuid(this string guidString)
        {
            return ToGuid(guidString, Guid.Empty);
        }

        public static Guid ToGuid(this string guidString, Guid def)
        {
            Guid
                guid = def;

            if (!guidString.IsGuid(out guid))
                return def;

            return guid;
        }
        public static bool IsGuid(this string guidString, out Guid guid)
        {
            guid = Guid.Empty;

            if (guidString.IsNullOrEmpty())
                return false;
            bool
                result = Guid.TryParse(guidString, out guid);

            return result;
        }    

        public static bool IsEmptyGuid(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static List<Guid> ToGuidList(this List<string> list)
        {
            return list.ToGuidList(true);
        }
        public static List<Guid> ToGuidList(this List<string> list, bool distinct)
        {
            List<Guid>
                gList = new List<Guid>();
            if (list == null || list.Count == 0)
                return gList;

            list.RemoveAll(item => item.IsNullOrEmpty());
            var
                l = distinct ? list.Distinct() : list;
            foreach (var o in l)
            {
                gList.Add(o.ToGuid());
            }

            return gList;
        }
        /// <summary>
        /// 转为int,默认0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return str.ToInt(0);
        }

        /// <summary>
        /// 转为int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="def">转换失败返回的默认值</param>
        /// <returns></returns>
        public static int ToInt(this string str, int def)
        {
            if (string.IsNullOrEmpty(str))
                return def;

            int
                i;
            bool
                result = int.TryParse(str, out i);

            return result ? i : def;
        }

        public static List<int> ToIntList(this List<string> list)
        {
            return list.ToIntList(true);
        }
        public static List<int> ToIntList(this List<string> list, bool distinct)
        {
            List<int>
                iList = new List<int>();
            if (list == null || list.Count == 0)
                return iList;
            var
                l = distinct ? list.Distinct() : list;
            foreach (var o in l)
            {
                if (o.IsNullOrEmpty())
                    continue;

                iList.Add(o.ToInt());
            }

            return iList;
        }

        public static long ToLong(this string str)
        {
            return str.ToLong(0);
        }

        public static long ToLong(this string str, long def)
        {
            if (string.IsNullOrEmpty(str))
                return def;

            long i;
            bool
                result = long.TryParse(str, out i);

            return result ? i : def;
        }
        public static List<long> ToLongList(this List<string> list)
        {
            return list.ToLongList(true);
        }
        public static List<long> ToLongList(this List<string> list, bool distinct)
        {
            List<long>
                iList = new List<long>();
            if (list == null || list.Count == 0)
                return iList;
            var
                l = distinct ? list.Distinct() : list;
            foreach (var o in l)
            {
                if (o.IsNullOrEmpty())
                    continue;

                iList.Add(o.ToInt());
            }

            return iList;
        }
        

        public static DateTime? ToDateTime(this string str)
        {
            if (str.IsNullOrEmpty())
                return null;
            DateTime time;
            bool result = DateTime.TryParse(str, out time);
            if (result)
                return time;
            else
                return null;
        }
        public static bool? ToBoolen(this string str)
        {
            if (str.IsNullOrEmpty())
                return null;
            bool
                b;
            bool
                result = Boolean.TryParse(str, out b);
            if (result)
                return b;
            else
                return null;
        }

        public static DateTime ToDateTime(this string str, DateTime def)
        {
            if (str.IsNullOrEmpty())
                return def;
            DateTime
                time;
            bool
                result = DateTime.TryParse(str, out time);

            return result ? time : def;
        }

        #region Check

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 指示指定的字符串由空白字符组成。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(this string str)
        {
            if (str.IsNullOrEmpty())
                return false;

            return Regex.IsMatch(str, @"^(\s+)$");
        } 
       

        /// <summary>
        /// 整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            if (str == null || str.Trim().Length == 0)
                return false;

            str = str.Trim();

            return Regex.IsMatch(str, @"^[-+]?\d+$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 实数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsReal(this string str)
        {
            if (str == null || str.Trim().Length == 0)
                return false;

            str = str.Trim();

            return Regex.IsMatch(str, @"^[-+]?\d+(\.\d+)?$", RegexOptions.IgnoreCase);
        }

        public static bool IsIPV4(this string ip)
        {
            if ((ip.IsNullOrEmpty()) || (ip.Length < 7) || (ip.Length > 15))
                return false;

            return Regex.IsMatch(ip, @"^\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}$", RegexOptions.IgnoreCase);
        }

        public static bool IsIPV6(this string ip)
        {
            if ((ip.IsNullOrEmpty()) || (ip.Length < 11) || (ip.Length > 23))
                return false;

            return Regex.IsMatch(ip, @"^\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}$", RegexOptions.IgnoreCase);
        }

        public static bool IsIP(this string ip)
        {
            return ip.IsIPV4() || ip.IsIPV6();
        }
        public static readonly string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public static bool IsEmail(this string str)
        {
            return str.IsMatch(EmailPattern);
        }

        public static readonly string MobilePattern = @"^1\d{10}$";
        public static bool IsMobile(this string str)
        {
            return str.IsMatch(MobilePattern);
        }

        public static readonly string CardIdPattern = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsCardId(this string str)
        {
            return str.IsMatch(CardIdPattern);
        }

        public static bool IsMatch(this string str, string pattern)
        {
            if (str.IsNullOrEmpty())
                return false;

            return Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
        }

        #endregion
    
    
    
    
    
    }
}
