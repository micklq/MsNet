using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Web;
using M2SA.AppGenome;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;
namespace MSNet.Common.Util
{
    public static class JsonExtension
    {      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            ArgumentAssertion.IsNotNull(obj, "obj");
            var json = JsonConvert.SerializeObject(obj, BuildSerializerSettings());
            return  json;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T ConvertEntity<T>(this string jsonData)
        {
            ArgumentAssertion.IsNotNull(jsonData, "jsonData");
            var entity = JsonConvert.DeserializeObject<T>(jsonData, BuildSerializerSettings());
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool TryConvertEntity<T>(this string jsonData, out T entity)
        {
            ArgumentAssertion.IsNotNull(jsonData, "jsonData");
            entity = default(T);
            try
            {
                entity = ConvertEntity<T>(jsonData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings BuildSerializerSettings()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                NullValueHandling = NullValueHandling.Ignore                

            };
            serializerSettings.Converters.Add(new DateTimeConvertor());            
            return serializerSettings;
        } 
        

        #region DateTimeConvertor

        /// <summary>
        /// 
        /// </summary>
        internal class DateTimeConvertor : DateTimeConverterBase
        {           
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {                
               return DateTime.SpecifyKind(DateTime.Parse(reader.Value.ToString()), DateTimeKind.Local).ToLocalTime();                 
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="serializer"></param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff"));                  
            }
        }

        #endregion

        public static string ToDynamicJson( dynamic obj )
        {
            return ToDynamicJson( obj, Newtonsoft.Json.Formatting.Indented );
        }

        public static string ToDynamicJson( dynamic obj, Newtonsoft.Json.Formatting formatting )
        {
            string json = JsonConvert.SerializeObject((object)obj, formatting);
            if (string.IsNullOrEmpty(json))
                return "";
            return HttpUtility.HtmlDecode(json);
        }
    }
}
