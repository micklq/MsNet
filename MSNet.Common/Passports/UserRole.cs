using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Passports.DataRepositories;
namespace MSNet.Common.Passports
{
    /// <summary>
    /// Role
    /// </summary>
    public class UserRole : EntityBase<long>
    {
        #region Instance Properties 
       
        public long RoleId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        public string Name { get; set; } 
        public string Description { get; set; }

        public string PermissionValues { get; set; }  
  		       
        #endregion


        #region Static Methods
        public static IList<UserRole> FindWithAll()
        {
            
            var repository = RepositoryManager.GetRepository<IUserRoleRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }
        

        public static UserRole FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IUserRoleRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IUserRoleRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IUserRoleRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

