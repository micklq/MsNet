using System;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        public TRepository GetRepository<TRepository>()
        {
            var repository = ObjectIOCFactory.GetSingleton<TRepository>();
            return (TRepository)repository;
        }
        
    }
}
