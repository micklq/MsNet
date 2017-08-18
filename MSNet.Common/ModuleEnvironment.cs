using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using M2SA.AppGenome.Reflection;
using MSNet.Common.Security;


namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ModuleEnvironment
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ModuleName = "MSNet.Common";
        /// <summary>
        /// 默认密码
        /// </summary>
        public static readonly string DefaultPassword = "654789";
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime EmptyDateTime = new DateTime(2000, 1, 1);
       

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string UserNamePattern = @"^[\d\w]{4,16}$"; //数字字母4-16位
        //internal static readonly string UserNamePattern = @"^[a-zA-Z]+[.-_a-zA-Z-9]{4,15}$";
        //internal static readonly string UserNamePattern = @"^(\d{18,18}|\d{15,15}|\d{17,17}x)|(1(\d){10})$";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string HashSalt = "qNTy12DY6rLD04Y0";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly string EncryptSalt = "02HnEOriXG4sNS12";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly int BCryptFactor = 6;        

        /// <summary>
        /// 
        /// </summary>
        public static readonly string WeakPasswords = @"000000,111111,11111111,123123,123456,1234567,12345678,654321,666666,888888,5201314,abc123,admin,root,qq123456,xiaoming,taobao,password,passw0rd,qwerty,qwerty,qweasd,qazwsx,superman";

        /// <summary>
        /// 
        /// </summary>
        internal static readonly PasswordStrength PasswordStrength = PasswordStrength.Average;

        static ModuleEnvironment()
        {
            UserNamePattern = GetValueFromConfig("passports:UserNamePattern", UserNamePattern);

            HashSalt = GetValueFromConfig("passports:Security.HashSalt", HashSalt);
            EncryptSalt = GetValueFromConfig("passports:Security.EncryptSalt", EncryptSalt);
            BCryptFactor = GetValueFromConfig("passports:Security.BCryptFactor", BCryptFactor);
            EncryptSalt = GetValueFromConfig("passports:Security.BCryptFactor", EncryptSalt);
            WeakPasswords = GetValueFromConfig("passports:Security.WeakPasswords", WeakPasswords);
            PasswordStrength = GetValueFromConfig("passports:Security.PasswordStrength", PasswordStrength);
        }

        private static T GetValueFromConfig<T>(string configKey, T defaultValue)
        {
            var configValue = ConfigurationManager.AppSettings.Get(configKey);
            if (string.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue.Convert<T>();
        }
    }
}
