using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    public enum PermissionType
    {
        // 读权限=1  读写权限=1+3=4  读写删权限=1+3+5=9  读删权限=1+5=6
       
        /// <summary>
        /// 读取信息
        /// </summary>
        Read = 1,
        /// <summary>
        /// 添加和修改
        /// </summary>
        Write = 3,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 5,
       
    }
}
