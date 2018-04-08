using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSNet.Common.Util;

namespace MSNet.Common.Web.Http
{
    /// <summary>
    /// 
    /// </summary>
    public static class AppClient
    {
        private static readonly string TokenKey = "MSNet-TOKEN";
        private static readonly string DeviceKey = "DeviceId";
        private static readonly string DeviceId = Guid.NewGuid().ToString("N");
        private static string AuthToken = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public static void SaveAuthToken(string token)
        {
            AuthToken = token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult HttpGet(string apiEndpoint)
        {
            return HttpGet(apiEndpoint,null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult HttpGet(string apiEndpoint, IList<KeyValuePair<string, object>> requestData)
        {
            var httpDecorator = new HttpDecorator();
            var headers = new Dictionary<string, string>();
            headers.Add(TokenKey, AuthToken);
            headers.Add(DeviceKey, DeviceId);
            var remoteApiEndpoint = apiEndpoint;
            remoteApiEndpoint = HttpDecorator.CombineRequest(remoteApiEndpoint, requestData);
            var responseResult = httpDecorator.HttpGet(remoteApiEndpoint, headers);
            return responseResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult HttpPost(string apiEndpoint, string postData)
        {
            var httpDecorator = new HttpDecorator();
            var headers = new Dictionary<string, string>();
            headers.Add(TokenKey, AuthToken);
            headers.Add(DeviceKey, DeviceId);
            var responseResult = httpDecorator.HttpPost(apiEndpoint, postData, headers);
            return responseResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult HttpPost(string apiEndpoint, object entity)
        {
            var postParams = entity.ToJson();
            return HttpPost(apiEndpoint, postParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult HttpPost(string apiEndpoint, IList<KeyValuePair<string, object>> postData)
        {
            var postParams = HttpDecorator.EncodeRequestData(postData);
            return HttpPost(apiEndpoint, postParams);
        }
    }
}
