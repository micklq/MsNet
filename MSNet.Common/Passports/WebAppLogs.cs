using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Threading;
using M2SA.AppGenome.Data;
using MSNet.Common.DataRepositories;


namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class WebAppLogs : EntityBase<long>
    {
        #region Instance Properties
        public long LogsId
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }
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


        public string Messages { get; set; }   

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
        public static IList<WebAppLogs> FindWithAll()
        {

            var repository = RepositoryManager.GetRepository<IWebAppLogsRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }

        public static WebAppLogs FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IWebAppLogsRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }


        public static IList<WebAppLogs> FindWithPage(string keyword, string beginTime, string endTime, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IWebAppLogsRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword, beginTime, endTime,page);
        }
        
        #endregion

        #region Persist Methods
        public void Insert()
        {
            var repository = RepositoryManager.GetRepository<IWebAppLogsRepository>(ModuleEnvironment.ModuleName);
            SmartThreadPool smartThreadPool = new SmartThreadPool();
            smartThreadPool.QueueWorkItem((obj) =>
            {
                repository.Insert((WebAppLogs)obj);
            }, this);            
        }  


        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IWebAppLogsRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

     
    }
}