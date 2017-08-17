using System;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Passports.DataRepositories;
using System.Collections;
using System.Collections.Generic;


namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserProfile : EntityBase<long>
    {
        #region Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public static UserProfile FindById(long passportId)
        {
            var repository = RepositoryManager.GetRepository<IUserProfileRepository>(ModuleEnvironment.ModuleName);
            var profile = repository.FindById(passportId);
            return profile;
        }

        public static long FindPassportIdByMobile(string Mobile)
        {
            var repository = RepositoryManager.GetRepository<IUserProfileRepository>(ModuleEnvironment.ModuleName);
            var model = repository.FindPassportIdByMobile(Mobile);
            return model;
        }  
    
        #endregion //Static Methods

      
        /// <summary>
        /// 
        /// </summary>
        public long PassportId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        ///手机号码 
        /// </summary>
        public string Mobile { get; set; }
        public string MobileText
        {
            get
            {
                if (string.IsNullOrEmpty(this.Mobile))
                {
                    return string.Empty;
                }
                var str1 = this.Mobile.Remove(0, 3);
                var str2 = str1.Remove(str1.Length - 3, 3);
                var str3 = string.Empty;
                for (int i = 0; i < str2.Length; i++)
                {
                    str3 += "*";
                }
                return this.Mobile.Replace(str2, str3);
            }
        } 
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; }      
        
      
        #region Persist Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool Save()
        {
            this.LastModifiedTime = DateTime.Now;
            var repository = RepositoryManager.GetRepository<IUserProfileRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
        }

        #endregion //Persist Methods
       
     
    }
}