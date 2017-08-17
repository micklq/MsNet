using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSNet.Common.Util;

namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    public enum SignUpStatus
    {        
        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("无")]
        None=0,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("成功")]
        Success = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("识别码错误")]
        InvalidIdentifyingCode = 2,

        /// <summary>
        /// 
        /// </summary>
         [EnumHelper.Description("cuow")]
        Error = 9,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("邮箱格式错误")]
        InvalidEmail = 101,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("手机格式错误")]
        InvalidMobilePhone = 102,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("用户名格式错误")]
        InvalidUserName = 103,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("密码错误")]
        InvalidPassword = 109,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("邮箱重复")]
        DuplicateEmail = 201,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("手机号重复")]
        DuplicateMobilePhone = 202,

        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("用户名重复")]
        DuplicateUserName = 203,

         /// <summary>
         /// 
         /// </summary>
         [EnumHelper.Description("用户锁定")]
         UserLocked = 900,

         /// <summary>
         /// 
         /// </summary>
         [EnumHelper.Description("用户休眠")]
         UserHibernation = 900,
 
        /// <summary>
        /// 
        /// </summary>
        [EnumHelper.Description("用户拒绝")]
         UserRejected = 995,

        /// <summary>
         /// 
         /// </summary>
         [EnumHelper.Description("用户作废")]
         UserCancellation = 999,

        
    }
}