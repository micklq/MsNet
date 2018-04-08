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
    public enum PermissionValue
    {
        // 添加=1  修改=2 删除=3 Read=4 
        // 读审删权限=1+3+7=11 读写删权限=1+5+7=13
       
        /// <summary>
        /// 添加
        /// </summary>
        [EnumHelper.Description("添加")]
        Add = 1,

        /// <summary>
        /// 修改
        /// </summary>        
        [EnumHelper.Description("修改")]
        Update = 2,

        /// <summary>
        /// 删除
        /// </summary>
        [EnumHelper.Description("删除")]
        Delete = 3,

        /// <summary>
        /// 查看
        /// </summary>
        [EnumHelper.Description("查看")]
        Read = 4,

        /// <summary>
        /// 审核
        /// </summary>
        [EnumHelper.Description("审核")]
        Audit = 5,        
       
    }
}
