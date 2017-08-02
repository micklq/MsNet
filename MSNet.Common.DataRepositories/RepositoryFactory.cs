using M2SA.AppGenome;
using M2SA.AppGenome.Data;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>()
        {
            var repository = ObjectIOCFactory.GetSingleton<TRepository>();
            return (TRepository)repository;
        }
    }
}
