using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Data;
using MSNet.Common.Passports.DataRepositories;
namespace MSNet.Common.Passports
{
    /// <summary>
    /// Permission
    /// </summary>
    public class Permission : BaseCategory<long>
    {

        //private static IPermissionRepository repository = new BaseRepositoryFactory().GetRepository<PermissionRepository>();

        #region Instance Properties     
          
        public long PermissionId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
     
        public int Sort { get; set; }    
        public string Value { get; set; }        
  		       
        #endregion

        #region Static Methods
        public static IList<Permission> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<Permission> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<Permission> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static Permission FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IPermissionRepository>(ModuleEnvironment.ModuleName);
            bool result = repository.Remove(this);
            //删除权限下角色
            result = result &&(RolePermission.RemoveByPermissionId(this.Id));    
       
            return result;
        }
        #endregion

    }
}

