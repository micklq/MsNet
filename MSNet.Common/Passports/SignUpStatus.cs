using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        None=0,

        /// <summary>
        /// 
        /// </summary>
        Success = 1,

        /// <summary>
        /// 
        /// </summary>
        InvalidIdentifyingCode = 2,

        /// <summary>
        /// 
        /// </summary>
        Error = 9,

        /// <summary>
        /// 
        /// </summary>
        InvalidEmail = 101,

        /// <summary>
        /// 
        /// </summary>
        InvalidMobilePhone = 102,

        /// <summary>
        /// 
        /// </summary>
        InvalidUserName = 103,

        /// <summary>
        /// 
        /// </summary>
        InvalidPassword = 109,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEmail = 201,

        /// <summary>
        /// 
        /// </summary>
        DuplicateMobilePhone = 202,

        /// <summary>
        /// 
        /// </summary>
        DuplicateUserName = 203,
        
        /// <summary>
        /// 
        /// </summary>
        UserRejected = 999
    }
}