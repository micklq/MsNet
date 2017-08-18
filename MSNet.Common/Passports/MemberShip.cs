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
using MSNet.Common.DataRepositories;
using MSNet.Common.Security;


namespace MSNet.Common
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
        public static AjaxResult SignUp(string mobile, string password, SignedUpInfo signedUpInfo, out UserPassport passport)
        {
            return SignUp(mobile, password, UserRoleType.Registered, 0, signedUpInfo, out passport);           
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
        public static AjaxResult SignUp(string mobile, string password, UserRoleType roleType, long roleId, SignedUpInfo signedUpInfo, out UserPassport passport)
        {  
             AjaxResult ajaxResult = CheckMobile(mobile); //核对手机是否已注册
             if (!ajaxResult.success){
                 passport = null;
                 return ajaxResult;
             }
             return SignUp(mobile, password, mobile, null, roleType, roleId, signedUpInfo, out passport);
            
        }

        private static AjaxResult SignUp(string userName, string password, string mobile, string email, UserRoleType roleType, long roleId, SignedUpInfo signedUpInfo, out UserPassport passport)
        {
            AjaxResult ajaxResult =  CheckUserName(userName);
            if (!ajaxResult.success) {
                passport = null;
                return ajaxResult;
            }            
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
            ajaxResult.success = false; 
            ajaxResult.message = "系统异常";
            if (userPassport.SignUp(signedUpInfo)){                
                ajaxResult.success = true; 
                ajaxResult.message = "注册成功";                
            }
            passport = userPassport;
            return ajaxResult;
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
        public static AjaxResult SignIn(string userKey, string password, out UserPassport userPassport)
        {
            ArgumentAssertion.IsNotNull(userKey, "userKey");
            ArgumentAssertion.IsNotNull( password, "password" );

            long passportId = 0;
            userPassport = null;
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
            if ( passportId > 0 )
            {
                userPassport = UserPassport.FindUserSecurityById(passportId);
                //判断状态 
                if (userPassport.PassportStatus == PassportStatus.Cancellation)
                {
                    return new AjaxResult { success = false, message = "账号已废弃" };                   
                }
                if (userPassport.PassportStatus == PassportStatus.Hibernation)
                {
                    return new AjaxResult { success = false, message = "账号已休眠,请于管理员联系" }; 
                }
                var ckResult =  PassportSecurityProvider.Verify(password, userPassport);
                if (ckResult)
                {
                    if (userPassport.PassportStatus == PassportStatus.Locked) {
                        UnLock(userPassport);
                    }                    
                   return new AjaxResult { success = true, message = "登录成功" }; 
                }
                else
                {
                    if (userPassport.PassportStatus == PassportStatus.Locked)
                    {
                        return new AjaxResult { success = false, message = "账号已锁定,请于管理员联系" }; 
                    }

                    userPassport.UserSecurity.FailedPasswordAttemptCount++;                  
                    if (userPassport.UserSecurity.FailedPasswordAttemptCount > 5)
                    {                        
                        Lock(userPassport);
                        return new AjaxResult { success = false, message = "5次密码输入错误,账号已锁定" };                        
                    }
                    userPassport.UserSecurity.Save(); //保存错误次数
                    return new AjaxResult { success = false, message = "用户密码错误！" };  
                }
            }
            return new AjaxResult { success = false, message = "用户不存在" };  
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
            userPassport.UserSecurity.LastLockedTime = DateTime.Now;
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
        public static AjaxResult Add(UserPassport passport, SignedUpInfo signedUpInfo, out UserPassport uPassport)
        {
            return SignUp(passport.UserName, passport.Password, passport.Mobile, passport.Email, passport.RoleType, passport.RoleId, signedUpInfo, out uPassport);            
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

        private static AjaxResult CheckEmail(string email)
        {           
            if (string.IsNullOrEmpty(email))
            {
                return new AjaxResult { success = false, message = "邮箱不能为空！" };
            } 
          
            if ( false == email.IsMatchEMail() ){
                return new AjaxResult { success = false, message = "邮箱格式错误！" };
            }            
            else
            {
                var passportId = UserPassport.FindPassportIdByEmail( email );
                if ( passportId > 0 )
                    return new AjaxResult() { success = false, message = "当前邮箱已存在！" };
            }
            return new AjaxResult() { success = true, message = "" };
        }

        private static AjaxResult CheckMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return new AjaxResult { success = false, message = "手机号不能为空！" };
            } 

            if ( false == mobile.IsMatchInteger() ){
                return new AjaxResult { success = false, message = "手机号格式错误！" };
            }                
            else
            {
                //Todo: FindUserIdByMonilePhone
                var passportId = UserPassport.FindPassportIdByMobile( mobile );
                if (passportId > 0) {
                    return new AjaxResult() { success = false, message = "当前手机号已存在！" };
                }                  
            }
            return new AjaxResult() { success = true, message = "" };
        }


        public static AjaxResult CheckUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)){
                return new AjaxResult { success = false, message = "用户名不能为空！" };
            }           

            var pat = ModuleEnvironment.UserNamePattern;
            //if ( HttpContext.Current != null && HttpContext.Current.Items.Contains( "UserNamePattern" ) )
            //    pat = HttpContext.Current.Items["UserNamePattern"] as string;
            //if ( string.IsNullOrEmpty(pat) )
            //    pat = ModuleEnvironment.UserNamePattern;
            if ( false == Regex.IsMatch( userName, pat ) ){
                return new AjaxResult() { success = false, message = "请输入4到16数字或字母组合！" };             
            }                
            else
            {
                var passportId = UserPassport.FindPassportIdByUserName(userName);
                if (passportId > 0) {
                    return new AjaxResult() { success = false, message = "当前用户名已存在！" };
                }                
            }
            return new AjaxResult() { success = true ,message="" };
        }

        #endregion


    }
}
