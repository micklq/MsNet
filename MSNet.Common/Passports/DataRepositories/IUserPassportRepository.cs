using System;
using System.Collections.Generic;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserPassportRepository : IRepository<UserPassport, long>
    {
        IList<UserPassport> FindWithAdminPage(string keyword, long roleId, IList<long> exceptIds, Pagination page);

        IList<UserPassport> FindWithSysAdminPage(string keyword, IList<long> exceptIds, Pagination page);
        
        IList<UserPassport> FindByRoleWithPage(string keyword, long roleId, Pagination page);

        UserPassport FindByKeyword(string keyword);      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        long FindPassportIdByEmail(string email);

        long FindPassportIdByMobile(string mobile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        long FindPassportIdByUserName(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        UserPassport FindUserSecurityById(long passportId);
    
    }
}