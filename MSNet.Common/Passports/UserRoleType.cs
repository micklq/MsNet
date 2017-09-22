using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSNet.Common.Util;

namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    public enum UserRoleType
    {
        /// <summary>
        /// 系统用户
        /// </summary>
        [EnumHelper.Description("系统管理员")]
        System = 99999, 

        /// <summary>
        /// 注册用户
        /// </summary>
        [EnumHelper.Description("注册用户")]
        Registered=0,  

       /// <summary>
       /// 系统管理员
       /// </summary>
       [EnumHelper.Description("网站管理员")]
        Adminstrator = 1,

       /// <summary>
       /// 老师
       /// </summary>
       [EnumHelper.Description("老师")]
       Teacher = 2,

       /// <summary>
       /// 学生
       /// </summary>
      [EnumHelper.Description("学生")]
      Student = 3, 
      
      /// <summary>
      /// 企业
      /// </summary>
      [EnumHelper.Description("企业")]
      Enterprise = 4,       

      /// <summary>
      /// 代理机构
      /// </summary>
      [EnumHelper.Description("代理")]
      Agency = 5,       

       
    }
}
