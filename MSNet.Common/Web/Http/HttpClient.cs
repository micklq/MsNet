using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSNet.Common.Util;
namespace MSNet.Common.Web.Http
{
    public static class HttpClient
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult Get(string apiEndpoint)
        {
            return Get(apiEndpoint, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult Get(string apiEndpoint, IList<KeyValuePair<string, object>> requestData)
        {
            var httpDecorator = new HttpDecorator();
            var headers = new Dictionary<string, string>();           
            var remoteApiEndpoint =apiEndpoint;  //
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
        public static HttpDecorator.HttpResponseResult Post(string apiEndpoint, string postData)
        {
            var httpDecorator = new HttpDecorator();
            var headers = new Dictionary<string, string>();     
            var responseResult = httpDecorator.HttpPost(apiEndpoint, postData, headers);
            return responseResult;
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult Post(string apiEndpoint, object entity)
        {
            var postParams = entity.ToJson();
            return Post(apiEndpoint, postParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static HttpDecorator.HttpResponseResult Post(string apiEndpoint, IList<KeyValuePair<string, object>> postData)
        {
            var postParams = HttpDecorator.EncodeRequestData(postData);
            return Post(apiEndpoint, postParams);
        }

        public static HttpDecorator.HttpResponseResult Post(string apiEndpoint, byte[] postData)
        {
            var httpDecorator = new HttpDecorator();
            var headers = new Dictionary<string, string>();
            var responseResult = httpDecorator.HttpPost(apiEndpoint, postData, headers);
            return responseResult;
        }
        
    }
}
