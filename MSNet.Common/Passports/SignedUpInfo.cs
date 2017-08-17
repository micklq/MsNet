using System;
using M2SA.AppGenome.Data;
using MSNet.Common.Passports.DataRepositories;

namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class SignedUpInfo : EntityBase<long>
    {
        /// <summary>
        /// 
        /// </summary>
        public long PassportId{ get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        public DateTime SignedUpTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SignedUpIp { get; set; }
       
        
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

        /// <summary>
        /// 
        /// </summary>
        public string UtmSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InviteCode { get; set; }

       

        #region Persist Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<ISignedUpInfoRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
        }

        #endregion //Persist Methods
    }
}