﻿using System.Security.Cryptography.X509Certificates;
using M2SA.AppGenome.Data;

namespace MSNet.Common.Passports.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserSecurityRepository : IRepository<UserSecurity, long>
    {
    }
}