using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using MSNet.Common.Security;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.DataRepositories;
using System.Data.SqlClient;


namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserPassport : EntityBase<long>
    {       

        #region Instance Properties      

        /// <summary>
        /// 
        /// </summary>
        public long PassportId
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
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            get;
            set;
        }
        public long RoleId
        {
            get;
            set;
        }

        public UserRoleType RoleType
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int PassportStatus
        {
            get;
            set;
        }

        #endregion //Instance Properties

        #region Extends Properties
        public string Password
        {
            get;
            set;
        }

        [NonSerialized]
        private UserSecurity userSecurity;

        /// <summary>
        /// 
        /// </summary>
        [NonSerializedProperty]
        public UserSecurity UserSecurity
        {
            get
            {
                return this.userSecurity;
            }
            set { this.userSecurity = value; }
        }

        [NonSerialized]
        private UserProfile profile;

        /// <summary>
        /// 
        /// </summary>
        [NonSerializedProperty]
        public UserProfile Profile
        {
            get
            {
                return this.LoadProfile();
            }
            set { this.profile = value; }
           
        }

        private UserRole role;

        public UserRole Role
        {
            get
            {
                return this.LoadRole();
            }
            set { this.role = value; }
        }

        private IList<UserRolePermission> rolePermissions;   
     
        public IList<UserRolePermission> RolePermissions
        {
            get
            {
                return this.LoadRolePermissions();
            }
            set { this.rolePermissions = value; }
        } 

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public UserPassport()
        {
            this.CreatedTime = DateTime.Now;
            this.LastModifiedTime = this.CreatedTime;
        }


        #region Private Properties Methods

        private UserProfile LoadProfile()
        {
            if (null != this.profile) {
                return this.profile;
            }
            if (this.PassportId == 0) {
                return null;
            }
            this.profile = UserProfile.FindById(this.PassportId);
           
            return this.profile;
        }


        private UserRole LoadRole()
        {
            if (null != this.role){
                return this.role;
            }
            if (this.RoleId == 0){
                return null;
            }

            this.role = UserRole.FindById(this.RoleId);

            return this.role;
        }

        private IList<UserRolePermission> LoadRolePermissions()
        {
            if (null != this.rolePermissions)
            {
                return this.rolePermissions;
            }
            if (this.RoleId == 0)
            {
                return null;
            }
            this.rolePermissions = UserRolePermission.FindByRoleId(this.RoleId);

            return this.rolePermissions;
        }

        #endregion

       


        #region Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static long FindPassportIdByEmail(string email)
        {
            ArgumentAssertion.IsNotNull(email, "email");
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.FindPassportIdByEmail(email);            
        }

        public static long FindPassportIdByMobile(string mobile)
        {
            ArgumentAssertion.IsNotNull(mobile, "mobile");
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.FindPassportIdByMobile(mobile);           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static long FindPassportIdByUserName(string userName)
        {
            ArgumentAssertion.IsNotNull(userName, "userName");
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.FindPassportIdByUserName(userName);

        }


        public static IList<UserPassport> FindWithAdminPage(string keyword, IList<long> exceptIds, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithAdminPage(keyword, exceptIds, page);
        }


        public static UserPassport FindByKeyword(string keyword)
        {
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByKeyword(keyword);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public static UserPassport FindById(long passportId)
        {
            if (passportId < 1)
                return null;

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            var passport = repository.FindById(passportId);
            return passport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public static UserPassport FindUserSecurityById(long passportId)
        {
            if (passportId < 1)
                return null;

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            var passport = repository.FindUserSecurityById(passportId);
            return passport;
        }

        #endregion 


        #region Persist Methods
      

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            this.LastModifiedTime = DateTime.Now;

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>( ModuleEnvironment.ModuleName );
            var result = false;
            if ( this.PersistentState == PersistentState.Transient && null != this.userSecurity )
            {
                //Todo：Must supporte transaction.
                //using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result = repository.Save( this );
                    if ( result && this.PassportId > 0 )
                    {                        
                        this.UserSecurity.Password = this.HashPassword( this.UserSecurity.Password );
                        this.UserSecurity.PassportId = this.PassportId;
                        result = this.UserSecurity.Save();

                        if ( result )
                        {
                            this.Profile.PassportId = this.PassportId;
                            result = this.Profile.Save();
                        }                        
                      
                    }
                    //transactionScope.Complete();
                }
            }
            else
            {
                result = repository.Save( this );
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>( ModuleEnvironment.ModuleName );          
            return repository.Remove( this );
        }

        /// <summary>
        /// 修改密码 可激活锁定休眠废弃用户
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ChangePassword( string password )
        {           
            this.UserSecurity.HashAlgorithm = null;
            this.UserSecurity.Password = this.HashPassword( password );
            this.UserSecurity.LastPasswordChangedTime = DateTime.Now;
            this.UserSecurity.UnLock();
            this.PassportStatus = (int)MSNet.Common.PassportStatus.Standard;
            var result = this.Save()&&this.UserSecurity.Save();
            return result;
        }      

        private string HashPassword( string password )
        {
            return PassportSecurityProvider.HashPassword( password, this );
        }

        public bool CheckPassword(string password)
        {
            return PassportSecurityProvider.Verify(password, this);
        }

        #endregion //Persist Methods

        #region SignUp & SignIn

        string GenerateCode()
        {
            var factor = 8659952100;
            return string.Format( "U{0}{1}", this.CreatedTime.Second / 10, ( this.PassportId + factor ).ToString().Substring( 1 ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SignUp( SignedUpInfo signedUpInfo )
        {
            //Todo：Must supporte transaction.
            //using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
               
                var result = this.Save();
                //var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);

                if ( null != signedUpInfo )
                {
                    signedUpInfo.SignedUpTime = this.CreatedTime;
                    signedUpInfo.PassportId = this.PassportId;
                    signedUpInfo.Save();
                }
                return result;
            }
        }

   

        #endregion 

       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetRealName()
        {
            var realName = null == this.Profile ? null : this.Profile.RealName;

            if ( string.IsNullOrEmpty( realName ) )
            {
                realName = this.UserName;
            }
           

            return realName;
        }
    }
}