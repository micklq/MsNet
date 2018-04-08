using System;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.DataRepositories;

namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserSecurity : EntityBase<long>
    {      

        /// <summary>
        /// 
        /// </summary>
        public long PassportId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HashAlgorithm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastPasswordChangedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLockedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FailedPasswordAttemptCount { get; set; }            
      

        /// <summary>
        /// 
        /// </summary>
        public UserSecurity()
        {
            this.LastPasswordChangedTime = DateTime.Now;
            this.LastLockedTime = ModuleEnvironment.EmptyDateTime;
        }

        

        #region Persist Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IUserSecurityRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal bool Delete()
        {
            var repository = RepositoryManager.GetRepository<IUserSecurityRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }

        #endregion //Persist Methods

        /// <summary>
        /// 
        /// </summary>
        internal void UnLock()
        {
            this.IsLocked = false;
            this.FailedPasswordAttemptCount = 0;
            //this.LastLockedTime = ModuleEnvironment.EmptyDateTime;
        }
    }
}
