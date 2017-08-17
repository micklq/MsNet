using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.BaseCategory;
using MSNet.Common.Passports.DataRepositories;
namespace MSNet.Common.Passports
{
    /// <summary>
    /// Permission
    /// </summary>
    public class PermissionMenu : BaseCategory<long>
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
        public static IList<PermissionMenu> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<PermissionMenu> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<PermissionMenu> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static PermissionMenu FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IPermissionMenuRepository>(ModuleEnvironment.ModuleName);
            bool result = repository.Remove(this);
            //ɾ��Ȩ���¹�����ɫ
            result = result &&(UserRolePermission.RemoveByPermissionId(this.Id));    
       
            return result;
        }
        #endregion

    }
}

