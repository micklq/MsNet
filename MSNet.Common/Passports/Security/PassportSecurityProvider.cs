using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using M2SA.AppGenome;

namespace MSNet.Common.Passports.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class PassportSecurityProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmName"></param>
        /// <returns></returns>
        public static IPassportSecurityStrategy LoadSecurityStrategy(string algorithmName)
        {
            IPassportSecurityStrategy securityStrategy = null;
            if (string.IsNullOrEmpty(algorithmName))
            {
                securityStrategy = ObjectIOCFactory.GetSingleton<BCryptSecurityStrategy>();
            }
            else
            {
                if (algorithmName == MD5SecurityStrategy.AlgorithmName)
                    securityStrategy = ObjectIOCFactory.GetSingleton<MD5SecurityStrategy>();
                else
                    securityStrategy = ObjectIOCFactory.GetSingleton<BCryptSecurityStrategy>();
            }
            return securityStrategy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        internal static string HashPassword(string password, UserPassport userPassport)
        {
            ArgumentAssertion.IsNotNull(userPassport, "userPassport");
            ArgumentAssertion.IsNotNull(userPassport.UserSecurity, "userPassport.UserSecurity");

            var securityStrategy = LoadSecurityStrategy(userPassport.UserSecurity.HashAlgorithm);
            return securityStrategy.HashPassword(password, userPassport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        internal static bool Verify(string password, UserPassport userPassport)
        {
            var securityStrategy = LoadSecurityStrategy(userPassport.UserSecurity.HashAlgorithm);
            return securityStrategy.Verify(password, userPassport);
        }
    }
}
