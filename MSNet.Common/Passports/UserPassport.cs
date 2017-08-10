using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using MSNet.Common.Passports.Security;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Passports.DataRepositories;
using System.Data.SqlClient;


namespace MSNet.Common.Passports
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserPassport : EntityBase<long>
    {
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
            var userId = repository.FindPassportIdByEmail(email);
            return userId;
        }

        public static long FindPassportIdByMobile(string mobile)
        {
            ArgumentAssertion.IsNotNull(mobile, "mobile");

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            var userId = repository.FindPassportIdByMobile(mobile);
            return userId;
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

        public static bool ClearRole(long roleId)
        {
            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            return repository.ClearRole(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public static UserPassport FindById( long passportId )
        {
            if ( passportId < 1 )
                return null;

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>(ModuleEnvironment.ModuleName);
            var passport = repository.FindById( passportId );
            return passport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public static UserPassport FindUserSecurityById( long passportId )
        {
            if ( passportId < 1 )
                return null;

            var repository = RepositoryManager.GetRepository<IUserPassportRepository>( ModuleEnvironment.ModuleName );
            var passport = repository.FindUserSecurityById( passportId );
            return passport;
        }

      

       

        #endregion //Static Methods

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
        /// <summary>
        /// 
        /// </summary>
        public PassportStatus PassportStatus
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

        private UserProfile profile;
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
            set
            {
                this.userSecurity = value;
                if (null != this.userSecurity)
                    this.userSecurity.UserPassport = this;
            }
        }
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
            set
            {
                this.profile = value;
                if (null != this.profile)
                    this.profile.UserPassport = this;
            }
        }

        private Role roles;
        public Role Roles
        {
            get
            {
                return this.LoadRoles();
            }
            set
            {
                this.roles = value;
            }
        }

        private IList<RolePermission> rolePermissions;
        public IList<RolePermission> RolePermissions
        {
            get
            {
                return this.LoadRolePermissions();
            }
            set
            {
                this.rolePermissions = value;
            }
        } 

        #endregion

        #region Private Properties Methods
        private Role LoadRoles()
        {
            if (null != this.roles)
                return this.roles;
            if (this.RoleId == 0)
                return null;

            this.roles = Role.FindById(this.RoleId);

            return this.roles;
        }

        private IList<RolePermission> LoadRolePermissions()
        {
            if (null != this.rolePermissions)
                return this.rolePermissions;
            if (this.RoleId == 0)
                return null;

            this.rolePermissions = RolePermission.FindByRoleId(this.RoleId);

            return this.rolePermissions;
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
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ChangePassword( string password )
        {           
            this.UserSecurity.HashAlgorithm = null;
            this.UserSecurity.Password = this.HashPassword( password );
            this.UserSecurity.LastPasswordChangedTime = DateTime.Now;
            this.UserSecurity.UnLock();
            var result = this.UserSecurity.Save();
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

   

        #endregion //SignUp & SignIn

        private UserProfile LoadProfile()
        {
            if ( null != this.profile )
                return this.profile;
            if ( this.PassportId == 0 )
                return null;


            this.profile = UserProfile.FindById( this.PassportId );

            if ( null != this.profile )
                this.profile.UserPassport = this;
            return this.profile;
        }

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