using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserProfileRepository : IRepository<UserProfile, long>
    {
        long FindPassportIdByMobile(string Mobile);
    }    

    
}