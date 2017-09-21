using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.DataRepositories;

namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Systemlogs : EntityBase<long>
    {
        #region Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public long PassportId{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserAction { get; set; }   

        /// <summary>
        /// 
        /// </summary>
        public string ClientIp { get; set; }
       
        
        /// <summary>
        /// 
        /// </summary>
        public string HttpUserAgent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HttpReferer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RefererDomain { get; set; }

        #endregion


        #region Static Methods
        public static IList<Systemlogs> FindWithAll()
        {

            var repository = RepositoryManager.GetRepository<ISystemlogsRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }

        public static IList<Systemlogs> FindWithPage(string keyword, string beginTime, string endTime, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<ISystemlogsRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword, beginTime, endTime,page);
        }
        
        #endregion

        #region Persist Methods
        public bool Insert()
        {
            var repository = RepositoryManager.GetRepository<ISystemlogsRepository>(ModuleEnvironment.ModuleName);
            return repository.Insert(this);

        }

        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<ISystemlogsRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

     
    }
}