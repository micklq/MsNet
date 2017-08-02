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
    public enum RoleType
    {
        /// <summary>
        /// 系统用户
        /// </summary>
        [EnumHelper.Description("系统用户")]
        SystemUser = -1, 

        /// <summary>
        /// 注册用户
        /// </summary>
        [EnumHelper.Description("注册用户")]
        RegisteredUser=0,  

       /// <summary>
       /// 系统管理员
       /// </summary>
       [EnumHelper.Description("系统管理员")]
       SuperAdmin = 1,

       /// <summary>
       /// 老师
       /// </summary>
       [EnumHelper.Description("老师")]
       Teacher = 2,

       /// <summary>
       /// 学生
       /// </summary>
      [EnumHelper.Description("学生")]
      Student = 3       

       
    }
}
