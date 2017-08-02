using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Web;
using MSNet.Common.Util;
using MSNet.Common.Passports.DataRepositories;
using MSNet.Common.Passports.Security;


namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemberShip
    {
        #region  用户注册

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>     
        /// <param name="signedUpInfo"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes" )]
        public static UserPassport SignUp(string userName, string password, SignedUpInfo signedUpInfo)
        {
            var status = SignUpStatus.Error;
            var passport = SignUp(null, userName, password, 0, signedUpInfo, out status);

            if ( null == passport )
                throw new Exception( status.ToString() );

            return passport;
        }

        public static UserPassport SignUp(string userName, string password, long roleId, SignedUpInfo signedUpInfo)
        {
            var status = SignUpStatus.Error;
            var passport = SignUp(null, userName, password, roleId, signedUpInfo, out status);

            if (null == passport)
                throw new Exception(status.ToString());

            return passport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>     
        /// <param name="signedUpInfo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static UserPassport SignUp(string email, string userName, string password, long roleId, SignedUpInfo signedUpInfo, out SignUpStatus status)
        { 
            //status = CheckPassword(password); //核对密码强度 
            //if (status != SignUpStatus.None) return null;

            return SignUp(email, null, userName, password, roleId, signedUpInfo, out status);
        }

        private static UserPassport SignUp(string email, string mobilePhone, string userName, string password, long roleId, SignedUpInfo signedUpInfo, out SignUpStatus status)
        {
            status = CheckUserName(userName);
            if (status != SignUpStatus.None)
                return null;

            status = CheckEmail(email); //核对邮箱是否已注册
            if (status != SignUpStatus.None) return null;    

            status = CheckMobile(mobilePhone); //核对手机是否已注册
            if (status != SignUpStatus.None) return null;

            var userPassport = new UserPassport() {
                UserSecurity = new UserSecurity(),
                Profile = new UserProfile()
            };
            userPassport.Email = email;
            userPassport.UserName = userName;
            userPassport.Mobile = mobilePhone;
            userPassport.RoleId = roleId;
            userPassport.UserSecurity.Password = password;
            userPassport.Profile.NickName = userName;           
            userPassport.Profile.Mobile = mobilePhone;
            userPassport.Profile.CreatedTime = userPassport.CreatedTime;           

            status = SignUpStatus.Error;
            if ( userPassport.SignUp( signedUpInfo ) )
                status = SignUpStatus.Success;
            return userPassport;
        }

        #endregion
        
        #region  用户登录
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool SignIn( string userKey, string password )
        {
            UserPassport userPassport = null;
            return SignIn( userKey, password, out userPassport );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        public static bool SignIn( string userKey, string password, out UserPassport userPassport )
        {
            ArgumentAssertion.IsNotNull( userKey, "userKey" );
            ArgumentAssertion.IsNotNull( password, "password" );

            long passportId = 0;
            if ( userKey.IsMatchEMail() )
            {
                passportId = UserPassport.FindPassportIdByEmail(userKey);
            }
            else if (userKey.IsMobile())
            {
                passportId = UserPassport.FindPassportIdByMobile(userKey);
            }
            else
            {
                passportId = UserPassport.FindPassportIdByUserName( userKey );
            }

            userPassport = null;
            var result = false;
            if ( passportId > 0 )
            {
                var passport = UserPassport.FindUserSecurityById( passportId );
                result = PassportSecurityProvider.Verify( password, passport );
                if (result)
                {
                    UnLock(passport);   
                }
                else
                {
                    passport.UserSecurity.FailedPasswordAttemptCount++;                     
                    if (passport.UserSecurity.FailedPasswordAttemptCount > 5)
                    {
                        Lock(passport);                         
                    }                    
                }
                userPassport = passport;         
               
            }
            return result;
        }


        #endregion

        #region  用户锁定
        public static bool UnLock(UserPassport userPassport)
        {
            var result = true;
            if (userPassport.PassportId > 0 && userPassport.UserSecurity!=null )
            {
               userPassport.UserSecurity.UnLock();
               userPassport.PassportStatus = PassportStatus.Standard;                
               result= result && userPassport.Save();
               result = result && userPassport.UserSecurity.Save(); 
            }
            return result;
        }

        public static bool Lock(UserPassport userPassport)
        {
            var result = true;
            if (userPassport.PassportId > 0 && userPassport.UserSecurity != null)
            {
                userPassport.PassportStatus = PassportStatus.Locked;
                userPassport.UserSecurity.IsLocked = true;              
                result = result && userPassport.Save();
                result = result && userPassport.UserSecurity.Save(); 
            }
            return result;
        }

        #endregion

        #region  用户添加 修改

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="email"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <param name="isLock"></param>
        /// <param name="signedUpInfo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool Add(UserPassport passport, SignedUpInfo signedUpInfo, out SignUpStatus status)
        {
            var result = false;
            UserPassport user = SignUp(passport.Email, passport.Mobile, passport.UserName, passport.Password, passport.RoleId, signedUpInfo, out status);
            if (status != SignUpStatus.None || status != SignUpStatus.Success)
            {
                return result;
            }
            user = UserPassport.FindUserSecurityById(user.PassportId);
            if (user == null)
            {
                return result;
            }
            if (passport.PassportStatus == PassportStatus.Locked)
            {
                result = Lock(user);
            }
            if (passport.PassportStatus == PassportStatus.Standard)
            {
                result = UnLock(user);
            }           
            return result;
        }

        /// <summary>
        /// 更新用户信息
        /// 状态 角色 登录信息更新
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="isLock"></param>
        /// <param name="signedUpInfo"></param>      
        /// <returns></returns>
        public static bool Update(UserPassport passport, SignedUpInfo signedUpInfo)
        {
            bool result = true;            
            UserPassport user = UserPassport.FindUserSecurityById(passport.PassportId);
            if (user == null)
            {               
                return false;
            }
            user.Email = passport.Email;
            user.Mobile = passport.Mobile;
            user.UserName = passport.UserName;
            user.RoleId = passport.RoleId;
            user.PassportStatus = passport.PassportStatus;
            if (user.UserName.IsNullOrEmpty())
            {
                user.Profile.NickName = passport.UserName;
            }
            if (user.Mobile.IsNullOrEmpty())
            {
                user.Profile.Mobile = passport.Mobile;
            }
            result = result && user.Save();
            result = result && user.Profile.Save();
            if (user.PassportStatus == PassportStatus.Locked)
            {
                result = result && Lock(user);
            }
            if (user.PassportStatus == PassportStatus.Standard)
            {
                result = result && UnLock(user);
            }
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="passportId"></param>
        /// <param name="oPassword">旧密码</param>
        /// <param name="nPasspword">新密码</param>
        /// <returns></returns>
        public static bool ChangePassword(long passportId, string oPassword, string nPasspword)
        {
            var result = false;
            if (passportId > 0)
            {
                var passport = UserPassport.FindUserSecurityById(passportId);
                if (passport == null) {
                    return false;
                }
                result = PassportSecurityProvider.Verify(oPassword, passport);
                if (result)
                {
                    result = passport.ChangePassword(nPasspword);
                }
            }
            return result;
        }

        #endregion

        #region  Check

        private static SignUpStatus CheckPassword(string password)
        {
            ArgumentAssertion.IsNotNull(password, "password");

            var signUpStatus = SignUpStatus.None;
            var passwordStrength = PasswordStrengthMarker.MarkStrength(password);
            if (passwordStrength < ModuleEnvironment.PasswordStrength)
                signUpStatus = SignUpStatus.InvalidPassword;

            return signUpStatus;
        }

        private static SignUpStatus CheckEmail( string email )
        {
            ArgumentAssertion.IsNotNull( email, "email" );

            var signUpStatus = SignUpStatus.None;
            if ( false == email.IsMatchEMail() )
                signUpStatus = SignUpStatus.InvalidEmail;
            else
            {
                var passportId = UserPassport.FindPassportIdByEmail( email );
                if ( passportId > 0 )
                    signUpStatus = SignUpStatus.DuplicateEmail;
            }
            return signUpStatus;
        }

        private static SignUpStatus CheckMobile( string mobile )
        {
            ArgumentAssertion.IsNotNull( mobile, "mobile" );

            var signUpStatus = SignUpStatus.None;

            if ( false == mobile.IsMatchInteger() )
                signUpStatus = SignUpStatus.InvalidMobilePhone;
            else
            {
                //Todo: FindUserIdByMonilePhone
                var passportId = UserPassport.FindPassportIdByEmail( mobile );
                if ( passportId > 0 )
                    signUpStatus = SignUpStatus.DuplicateMobilePhone;
            }
            return signUpStatus;
        }


        public static SignUpStatus CheckUserName( string userName )
        {
            var signUpStatus = SignUpStatus.None;

            if ( string.IsNullOrEmpty( userName ) )
                return signUpStatus;

            var pat = ModuleEnvironment.UserNamePattern;

            if ( HttpContext.Current != null && HttpContext.Current.Items.Contains( "UserNamePattern" ) )
                pat = HttpContext.Current.Items["UserNamePattern"] as string;

            if ( string.IsNullOrEmpty(pat) )
                pat = ModuleEnvironment.UserNamePattern;

            if ( false == Regex.IsMatch( userName, pat ) )
                signUpStatus = SignUpStatus.InvalidUserName;
            else
            {
                var passportId = UserPassport.FindPassportIdByUserName(userName);
                if ( passportId > 0 )
                    signUpStatus = SignUpStatus.DuplicateUserName;
            }

            return signUpStatus;
        }

        #endregion


    }
}
