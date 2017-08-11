using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSNet.Common.Util
{
    //枚举
    public static class EnumHelper
    {
        // Methods
        public static string GetDescription<TEnum>(TEnum item)
        {
            Type
                enumType = typeof(TEnum);
            int
                fieldValue = Convert.ToInt32(item);

            return GetDescription(enumType, fieldValue);
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="fieldValue">枚举值</param>
        /// <returns>枚举描述</returns>
        public static string GetDescription<TEnum>(int fieldValue)
        {
            Type
                enumType = typeof(TEnum);
            return GetDescription(enumType, fieldValue);
        }
        public static string GetDescription<TEnum>(string fieldName)
        {
            Type
                enumType = typeof(TEnum);
            return GetDescription(enumType, fieldName);
        }
        public static string GetDescription(Type enumType, int fieldValue)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("enumItem requires a Enum ");

            var
                o = GetItems(enumType).Find(item => item.Value == fieldValue);
            return
                o == null ? "" : o.Description;
        }
        public static string GetDescription(Type enumType, string fieldName)
        {
            return GetDescription(enumType, fieldName, fieldName);
        }
        public static string GetDescription(Type enumType, string fieldName, string def)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("enumItem requires a Enum ");

            if (def == null)
                def = "";
            if (fieldName.IsNullOrEmpty())
                return def;
            var
                items = GetItems(enumType);
            var
                o = items.Find(item => item.Name == fieldName);
            if (o == null)
                return def;

            return o.Description.IsNullOrEmpty() ? def : o.Description;
        }

        public static List<string> GetDescriptions<TEnum>()
        {
            return GetDescriptionsString<TEnum>().Values.ToList<string>();
        }
        public static List<string> GetDescriptions(this List<EnumItem> list)
        {
            List<string>
                list2 = new List<string>();
            foreach (EnumItem item in list)
            {
                list2.Add(item.Description);
            }
            return list2;
        }
        public static List<string> GetDescriptions(Type enumType)
        {
            return GetDescriptionsString(enumType).Values.ToList<string>();
        }

        public static Dictionary<int, string> GetDescriptionsInt<TEnum>()
        {
            Type
                enumType = typeof(TEnum);

            return GetDescriptionsInt(enumType);
        }
        public static Dictionary<int, string> GetDescriptionsInt(Type enumType)
        {
              var
                    d = new Dictionary<int, string>();
                var
                    items = GetItems(enumType);
                foreach (var o in items)
                {
                    d.Add(o.Value, o.Description);
                }
                return d;           
        }

        public static Dictionary<string, string> GetDescriptionsString<TEnum>()
        {
            Type
                enumType = typeof(TEnum);
            return GetDescriptionsString(enumType);
        }
        public static Dictionary<string, string> GetDescriptionsString(Type enumType)
        {
            var
                     d = new Dictionary<string, string>();
            var
                items = GetItems(enumType);
            foreach (var o in items)
            {
                d.Add(o.Name, o.Description);
            }
            return d;
            
        }

        public static List<string> GetNames(this List<EnumItem> list)
        {
            List<string>
                list2 = new List<string>();
            foreach (EnumItem item in list)
            {
                list2.Add(item.Name);
            }
            return list2;
        }
        public static List<int> GetValues(this List<EnumItem> list)
        {
            List<int> list2 = new List<int>();
            foreach (EnumItem item in list)
            {
                list2.Add(item.Value);
            }
            return list2;
        }
        public static int? GetValueByDescription(Type enumType, string description)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("enumItem requires a Enum ");

            if (description.IsNullOrEmpty())
                return null;

            var items = GetItems(enumType);

            var o = items.Find(item => item.Description.IsEquals(description));
            if (o == null)
                return null;

            return o.Value;
        }

        public static int GetValue<TEnum>(string fieldName)
        {
            Type enumType = typeof(TEnum);
            return GetValue(enumType, fieldName, 0);
        }

        public static int GetValue(Type enumType, string fieldName)
        {
            return GetValue(enumType, fieldName, 0);
        }
        public static int GetValue(Type enumType, string fieldName, int def)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("enumItem requires a Enum ");
            if (fieldName.IsNullOrEmpty())
                return def;            

            var
               items = GetItems(enumType);
            var
                o = items.Find(item => item.Name == fieldName);
            if (o == null)
                return def;

            return o.Value;
        }

        /// <summary>
        /// 获取所有枚举项
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static List<EnumItem> GetItems<TEnum>()
        {
            Type
                enumType = typeof(TEnum);

            return GetItems(enumType);
        }
        /// <summary>
        /// 获取所有枚举项
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static List<EnumItem> GetItems(Type enumType)
        {
            string
                key = enumType.FullName + ".GetItems";
            List<EnumItem>
                   list = new List<EnumItem>();
            string[]
                names = Enum.GetNames(enumType);
            Array
                values = Enum.GetValues(enumType);
            Dictionary<string, string>
                d = new Dictionary<string, string>();
            Type
                attrType = typeof(DescriptionAttribute);
            foreach (var fieldName in names)
            {
                DescriptionAttribute
                    attribute = (from a in enumType.GetField(fieldName).GetCustomAttributes(attrType, false)
                                 select a
                                  ).FirstOrDefault() as DescriptionAttribute;

                var
                    description = attribute == null ? fieldName : (attribute.Description.IsNullOrEmpty() ? fieldName : attribute.Description);

                d.Add(fieldName, description);
            }

            for (var i = 0; i < names.Length; i++)
            {
                list.Add(new EnumItem()
                {
                    Name = names[i],
                    Value = Convert.ToInt32(values.GetValue(i)),
                    Description = d[names[i]]
                });
            }
            return list;            
        }

        /// <summary>
        /// 枚举描述属性
        /// </summary>
        public class DescriptionAttribute : Attribute
        {
            /// <summary>
            /// 枚举描述
            /// </summary>
            /// <param name="txt">枚举描述</param>
            public DescriptionAttribute(string description)
            {
                this.Description = description;
            }

            /// <summary>
            /// 枚举描述
            /// </summary>
            public string Description
            {
                get;
                set;
            }
        }

        [Serializable]
        public class EnumItem
        {
            /// <summary>
            /// 枚举名称
            /// </summary>
            public string Name
            {
                get;
                set;
            }

            /// <summary>
            /// 枚举值
            /// </summary>
            public int Value
            {
                get;
                set;
            }
            /// <summary>
            /// 枚举描述
            /// </summary>
            public string Description
            {
                get;
                set;
            }
        }
    }
}
