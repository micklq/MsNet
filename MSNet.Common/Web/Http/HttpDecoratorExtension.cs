using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M2SA.AppGenome;
using M2SA.AppGenome.Reflection;
using MSNet.Common.Util;
namespace MSNet.Common.Web.Http
{
    public static class HttpDecoratorExtension
    {
        /// <summary>
        /// Json序列化
        /// </summary>
        public static IList<KeyValuePair<string, object>> Add(this IList<KeyValuePair<string, object>> postData, string key, object value)
        {
            ArgumentAssertion.IsNotNull(postData, "postData");
            postData.Add(new KeyValuePair<string, object>(key, value));
            return postData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="apiUri"></param>
        /// <returns></returns>
        public static string TransformAPIUri(this object queryObject, string apiUri)
        {
            var requestData = queryObject.TransformAPIJson();

            var queryUrl = HttpDecorator.CombineRequest(apiUri, requestData);
            return queryUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public static IList<KeyValuePair<string, object>> TransformAPIJson(this object queryObject)
        {
            var propertyValues = queryObject.GetPropertyValues();
            var requestData = new List<KeyValuePair<string, object>>(propertyValues.Count);
            foreach (var item in propertyValues)
            {
                if (null == item.Value)
                    continue;

                if (item.Value is Array)
                    requestData.Add(FormatJsonName(item.Key), string.Format("{{\"{0}\":{1}}}", FormatJsonName(item.Key), item.Value.ToJson()));
                else if (item.Value is DateTime)
                    requestData.Add(FormatJsonName(item.Key), item.Value.ToJson().ToLower());
                else if (item.Value is bool)
                    requestData.Add(FormatJsonName(item.Key), item.Value.ToJson().ToLower());
                else
                    requestData.Add(FormatJsonName(item.Key), item.Value.ToJson());
            }
            return requestData;
        }

        private static string FormatJsonName(string key)
        {
            return string.Concat(key.Substring(0, 1).ToLower(), key.Substring(1));
        }
    }
}
