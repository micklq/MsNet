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
    /// Permission
    /// </summary>
    public class Permissions : BaseCategory<long>
    {

        //private static IPermissionRepository repository = new BaseRepositoryFactory().GetRepository<PermissionRepository>();

        #region Instance Properties     
          
        public long PermissionId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
     
        public int Sort { get; set; }
        public string Url { get; set; }        
  		       
        #endregion

        #region Static Methods
        public static IList<Permissions> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<Permissions> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<Permissions> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static Permissions FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IPermissionsRepository>(ModuleEnvironment.ModuleName);            
            return repository.Remove(this);            
        }
        #endregion

    }
}

