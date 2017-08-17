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
        /// 普通用户注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>     
        /// <param name="signedUpInfo"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes" )]
        public static UserPassport SignUp(string mobile, string password, SignedUpInfo signedUpInfo, out SignUpStatus status)
        {                   
             return SignUp(mobile, password, UserRoleType.Registered, 0, signedUpInfo, out status);           
        }
        /// <summary>
        /// 普通用户 老师 学生注册
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <param name="roleType"></param>
        /// <param name="roleId"></param>
        /// <param name="signedUpInfo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static UserPassport SignUp(string mobile, string password, UserRoleType roleType, long roleId, SignedUpInfo signedUpInfo, out SignUpStatus status)
        {
            status = SignUpStatus.None;
            //status = CheckPassword(password); //核对密码强度 
            //if (status != SignUpStatus.None) return null;

            status = CheckMobile(mobile); //核对手机是否已注册
            if (status != SignUpStatus.None) return null;

            var passport = SignUp(mobile, password, mobile, null, roleType, roleId, signedUpInfo, out status);

            if (null == passport)
                throw new Exception(status.ToString());

            return passport;
        }
        

        private static UserPassport SignUp(string userName, string password, string mobile, string email, UserRoleType roleType, long roleId, SignedUpInfo signedUpInfo, out SignUpStatus status)
        {
            status = SignUpStatus.None;
            status = CheckUserName(userName);
            if (status != SignUpStatus.None) return null;
            //status = CheckEmail(email); //核对邮箱是否已注册
            //if (status != SignUpStatus.None) return null;             

            var userPassport = new UserPassport() {
                UserSecurity = new UserSecurity(),
                Profile = new UserProfile()
            };
            userPassport.UserName = userName;
            userPassport.Mobile = mobile;
            userPassport.Email = email;
            userPassport.RoleType = roleType;
            userPassport.RoleId = roleId;
            userPassport.UserSecurity.Password = password;
            userPassport.Profile.NickName = userName;           
            userPassport.Profile.Mobile = mobile;
            userPassport.Profile.CreatedTime = userPassport.CreatedTime;           

            status = SignUpStatus.Error;
            if (userPassport.SignUp(signedUpInfo)){
                status = SignUpStatus.Success;
            }               
            return userPassport;
        }

        #endregion
        
        #region  用户登录    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="password"></param>
        /// <param name="userPassport"></param>
        /// <returns></returns>
        public static bool SignIn(string userKey, string password, out UserPassport userPassport, out SignUpStatus status)
        {
            ArgumentAssertion.IsNotNull(userKey, "userKey");
            ArgumentAssertion.IsNotNull( password, "password" );

            long passportId = 0;
            if (userKey.IsMatchEMail())
            {
                passportId = UserPassport.FindPassportIdByEmail(userKey);
            }
            else if (userKey.IsMobile())
            {
                passportId = UserPassport.FindPassportIdByMobile(userKey);
            }
            else
            {
                passportId = UserPassport.FindPassportIdByUserName(userKey);
            }

            userPassport = null;
            status = SignUpStatus.None;
            var result = false;
            if ( passportId > 0 )
            {
                var passport = UserPassport.FindUserSecurityById( passportId );
                //判断状态 
                if (passport.PassportStatus == PassportStatus.Cancellation) {
                    status = SignUpStatus.UserCancellation;
                    return false;
                }
                if (passport.PassportStatus == PassportStatus.Hibernation)
                {
                    status = SignUpStatus.UserHibernation;
                    return false;
                }
                result = PassportSecurityProvider.Verify( password, passport );
                if (result)
                {
                    UnLock(passport);   
                }
                else
                {
                    if (passport.PassportStatus == PassportStatus.Locked)
                    {
                        status = SignUpStatus.UserLocked;
                        return false;
                    }

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
            if (userPassport.PassportId < 1 || userPassport.UserSecurity == null) return false;            
            
            userPassport.UserSecurity.UnLock();
            userPassport.PassportStatus = PassportStatus.Standard;                
            return userPassport.Save()&& userPassport.UserSecurity.Save();              
        }

        public static bool Lock(UserPassport userPassport)
        {
           if(userPassport.PassportId <1 || userPassport.UserSecurity == null) return false;
           
            userPassport.PassportStatus = PassportStatus.Locked;
            userPassport.UserSecurity.IsLocked = true;
            return userPassport.Save() && userPassport.UserSecurity.Save();   
            
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
            UserPassport user = SignUp(passport.UserName, passport.Password, passport.Mobile, passport.Email, passport.RoleType, passport.RoleId, signedUpInfo, out status);
            if (user == null)
            {
                return false;
            }           
            return true;
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
            if (!passport.Mobile.IsNullOrEmpty()&&passport.Mobile != user.Mobile)
            {
                user.Mobile = passport.Mobile;
            }
            if (!passport.Email.IsNullOrEmpty() && passport.Email != user.Email)
            {
                user.Email = passport.Email; 
            }
            if (passport.RoleId != user.RoleId)
            {
                user.RoleId = passport.RoleId;
            }
            if (!user.Mobile.IsNullOrEmpty() && user.Mobile != user.Profile.Mobile)
            {
                user.Profile.Mobile = user.Mobile;
            }
            result = user.Profile.Save(); //更新profile 
            if (passport.PassportStatus != user.PassportStatus)
            {
                if (passport.PassportStatus == PassportStatus.Locked)
                {
                    result = Lock(user);
                }
                if (passport.PassportStatus == PassportStatus.Standard)
                {
                    result = UnLock(user);
                }
                user.PassportStatus = passport.PassportStatus;
            }            
            result = user.Save();    

            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="passportId"></param>
        /// <param name="oPassword">旧密码</param>
        /// <param name="nPasspword">新密码</param>
        /// <returns></returns>
        public static bool ModifyPassword(long passportId, string oPassword, string nPasspword)
        {
            var result = false;
            if (passportId > 0)
            {
                var passport = UserPassport.FindUserSecurityById(passportId);
                if (passport == null) {
                    return false;
                }
                result = passport.CheckPassword(oPassword);                
                if (result)
                {
                    result = passport.ChangePassword(nPasspword);
                }
            }
            return result;
        }

        #endregion

        #region  Check

        private static SignUpStatus CheckPasswordStrength(string password)
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
                var passportId = UserPassport.FindPassportIdByMobile( mobile );
                if ( passportId > 0 )
                    signUpStatus = SignUpStatus.DuplicateMobilePhone;
            }
            return signUpStatus;
        }


        public static SignUpStatus CheckUserName( string userName )
        {
            var signUpStatus = SignUpStatus.Error;

            if ( string.IsNullOrEmpty( userName ) )
                return signUpStatus;

            var pat = ModuleEnvironment.UserNamePattern;

            //if ( HttpContext.Current != null && HttpContext.Current.Items.Contains( "UserNamePattern" ) )
            //    pat = HttpContext.Current.Items["UserNamePattern"] as string;

            //if ( string.IsNullOrEmpty(pat) )
            //    pat = ModuleEnvironment.UserNamePattern;

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
