using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using M2SA.AppGenome;

namespace MSNet.Common.Security
{
    class MD5SecurityStrategy : IPassportSecurityStrategy
    {
        internal static readonly string AlgorithmName = "MD5";

        private static readonly string SecuritySalt = "MSNet.Common";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        string IPassportSecurityStrategy.HashPassword(string password, UserPassport userPassport)
        {
            ArgumentAssertion.IsNotNull(password, "password");
            ArgumentAssertion.IsNotNull(userPassport, "userPassport");
            ArgumentAssertion.IsNotNull(userPassport.UserSecurity, "userPassport.UserSecurity");

            if (string.IsNullOrEmpty(userPassport.UserSecurity.HashAlgorithm))
            {
                var saltLength = new Random(Environment.TickCount - password.Length).Next(7, 12);
                userPassport.UserSecurity.HashAlgorithm = AlgorithmName;
                userPassport.UserSecurity.PasswordSalt = GenerateSalt(saltLength);
            }

            password = FormatPassword(password, userPassport);
            return ComputeHash(password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        bool IPassportSecurityStrategy.Verify(string password, UserPassport userPassport)
        {
            ArgumentAssertion.IsNotNull(userPassport, "userPassport");
            ArgumentAssertion.IsNotNull(userPassport.UserSecurity, "userPassport.UserSecurity");

            password = FormatPassword(password, userPassport);
            var passwordHash = ComputeHash(password);
            return passwordHash == userPassport.UserSecurity.Password;
        }

        static string ComputeHash(string password)
        {
            using ( MD5 md5 = MD5.Create() )
            {
                byte[] p = md5.ComputeHash( Encoding.UTF8.GetBytes( password ) );
                string pwd = "";
                for ( int i = 0; i < p.Length; i++ )
                {
                    pwd += p[i].ToString( "X" );
                }
                return pwd;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatTimes"></param>
        /// <returns></returns>
        static string GenerateSalt(int formatTimes)
        {
            byte[] rnd = new byte[formatTimes + ModuleEnvironment.BCryptFactor];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(rnd);
            }
            var salt = Convert.ToBase64String(rnd);
            return salt;
        }

        static string FormatPassword(string password, UserPassport userPassport)
        {
            var passwordFactors = string.Concat(password, userPassport.UserSecurity.PasswordSalt, SecuritySalt);

            return passwordFactors;
        }
    }
}
