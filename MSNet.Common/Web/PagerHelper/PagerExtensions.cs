using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MSNet.Common.Web.Pager
{
    public static class PagerExtensions
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptys(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static string StringFormat(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        #region JoinUrl

        /// <summary>
        /// 连接成字符串，默认以 1,2,3,4 的格式输出
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static string JoinUrl(this List<int> list)
        {
            return list.JoinUrl("", ",");
        }

        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="format">格式</param>
        /// <param name="joinChar">连接符</param>
        /// <returns></returns>
        public static string JoinUrl(this List<int> list, string format, string joinChar)
        {
            return JoinUrl<int>(list, format, joinChar);
        }

        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string JoinUrl(this List<string> list)
        {
            return list.JoinUrl("", ",");
        }

        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <param name="list"></param>
        /// <param name="format"></param>
        /// <param name="joinChar"></param>
        /// <returns></returns>
        public static string JoinUrl(this List<string> list, string format, string joinChar)
        {
            return JoinUrl<string>(list, format, joinChar);
        }

        public static string JoinUrl(this List<Guid> list)
        {
            return list.JoinUrl("{0}", ",");
        }

        public static string JoinUrl(this List<Guid> list, string format, string joinChar)
        {
            //return list.ToStringList().JoinUrl( format, joinChar );
            return JoinUrl<Guid>(list, format, joinChar);
        }

        /// <summary>
        /// 连接成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="format"></param>
        /// <param name="joinChar"></param>
        /// <returns></returns>
        public static string JoinUrl<T>(List<T> list, string format, string joinChar)
        {
            if (format.IsNullOrEmptys())
                format = "\"{0}\"";
            StringBuilder
                sbList = new StringBuilder("");
            foreach (T item in list)
            {
                sbList.AppendFormat(format, item).Append(joinChar);
            }
            return sbList.ToString().TrimEnd(joinChar);
        }
        public static string TrimEnd(this string str, string trimStr)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            while (str.EndsWith(trimStr))
            {
                str = str.Substring(0, str.Length - trimStr.Length);
            }

            return str;
        }
        #endregion
        public static Dictionary<string, string> GetQueryStrings(this Uri uri)
        {
            return GetQueryStrings(uri, null);
        }

        public static Dictionary<string, string> GetQueryStrings(this Uri uri, params string[] ignoreKeys)
        {
            var d2 = new Dictionary<string, string>();

            if (uri == null)
                return d2;

            var query = uri.Query;
            if (query.IsNullOrEmptys())
                return d2;

            if (query.StartsWith("?"))
                query = query.Trim('?');

            if (query.IsNullOrEmptys())
                return d2;

            if (ignoreKeys == null)
                ignoreKeys = new string[0];

            List<string>   ignoreQueryKeys = ignoreKeys.Distinct().ToList();

          
            var d = new Dictionary<string, string>();

            var arr = query.Split('&');

            foreach (var o in arr)
            {
                if (o.IsNullOrEmptys())
                    continue;

                var arr2 = o.Split('=');

                if (arr2.Length == 0)
                    continue;

                var key = arr2[0].ToLower();

                if (ignoreQueryKeys.Contains(key))
                    continue;

                var v = "";

                if (arr2.Length > 1)
                    v = arr2[1];

                if (d.ContainsKey(key))
                {
                    if (!v.IsNullOrEmptys())
                    {
                        var ov = d[key];
                        if (!ov.IsNullOrEmptys())
                            ov += ",";
                        ov += v;

                        d[key] = ov;

                    }
                }
                else
                {
                    d.Add(key, v);
                }
            }

            return d;

            //}, 86400 );

            //return d2;
        }

        public static string GetQueryString(this Uri uri, string key)
        {
            if (key.IsNullOrEmptys())
                return null;

            key = key.ToLower();

            var d = uri.GetQueryStrings();

            if (d.ContainsKey(key))
                return d[key];

            return null;
        }

        public static string ToStringWithoutQuery(this Uri uri)
        {
            string url = uri.ToString();
            var idx = url.IndexOf('?');
            if (idx < 0)
                return url;

            return url.Substring(0, idx);
        }

        public static string ToStringWithoutHash(this Uri uri)
        {
            string url = uri.ToString();
            var idx = url.IndexOf('#');
            if (idx < 0)
                return url;

            return url.Substring(0, idx);
        }

        public static string ToStringWithoutQueryAndHash(this Uri uri)
        {
            string
                url = uri.ToString();

            var
                idx = url.IndexOf('?');
            if (idx >= 0)
                url = url.Substring(0, idx);

            idx = url.IndexOf('#');
            if (idx >= 0)
                url = url.Substring(0, idx);

            return url;
        }
        public static Uri ToUri(this string url)
        {
            Uri _uri = null;

            if (url.IsNullOrEmptys())
                return _uri;

            var b = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out _uri);

            return _uri;
        }

        public static string ToSortedQueryStringUrl(this Uri uri)
        {
            return ToSortedQueryStringUrl(uri, SortOrder.Ascending);
        }

        public static string ToSortedQueryStringUrl(this Uri uri, SortOrder sort)
        {
            if (uri == null)
                return "";

            List<KeyValuePair<string, string>> d;

            if (sort == SortOrder.Descending)
                d = uri.GetQueryStrings().OrderByDescending(o => o.Key).ToList();
            else
                d = uri.GetQueryStrings().OrderBy(o => o.Key).ToList();

            var _url = uri.ToStringWithoutQuery();

            var list = new List<string>();
            foreach (var o in d)
            {
                list.Add("{0}={1}".StringFormat(o.Key, o.Value));
            }

            _url += ("?" + list.JoinUrl("{0}", "&"));

            return _url;
        }

        public static Uri BuildNewUri(this Uri uri, params string[] ignoreKeys)
        {
            if (ignoreKeys == null || ignoreKeys.Length == 0)
                return uri;

            Dictionary<string, string> d = uri.GetQueryStrings(ignoreKeys);

            var _url = uri.ToStringWithoutQuery();

            var list = new List<string>();
            foreach (var o in d)
            {
                list.Add("{0}={1}".StringFormat(o.Key, o.Value));
            }

            _url += ("?" + list.JoinUrl("{0}", "&"));

            _url = _url.TrimEnd('?', '&');

            return _url.ToUri();

        }
        public static Uri BuildNewUri(this Uri uri, string key, string value, params string[] ignoreKeys)
        {
            if (uri == null)
                return uri;

            if (value == null)
                value = "";

            Dictionary<string, string> d = uri.GetQueryStrings(ignoreKeys);

            if (!key.IsNullOrEmptys())
            {
                if (!d.ContainsKey(key))
                    d.Add(key, value);
                else
                    d[key] = value;
            }

            var _url = uri.ToStringWithoutQuery();

            var list = new List<string>();
            foreach (var o in d)
            {
                list.Add("{0}={1}".StringFormat(o.Key, o.Value));
            }

            _url += ("?" + list.JoinUrl("{0}", "&"));

            _url = _url.TrimEnd('?', '&');

            return _url.ToUri();
        }

    }
}
