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
    public enum PassportStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [EnumHelper.Description("正常")]
        Standard = 0,

        /// <summary>
        /// 锁定
        /// </summary>
        [EnumHelper.Description("锁定")]
        Locked = 500,

        /// <summary>
        /// 休眠
        /// </summary>
        [EnumHelper.Description("休眠")]
        Hibernation = 900,

        /// <summary>
        /// 作废
        /// </summary>
        [EnumHelper.Description("作废")]
        Cancellation = 999
    }
}
