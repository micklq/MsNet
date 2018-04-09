using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common;
using MSNet.Common.DataRepositories;
namespace MSNet.Common
{
    /// <summary>
    /// TitleCategory
    /// </summary>
    public class MasterCategory : BaseCategory<long>
    {
        #region Instance Properties     
          
        public long CategoryId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
     
        public int Sort { get; set; }

        #endregion

        #region Extends Properties
        public string ImageUrls
        {
            get;
            set;
        }
        #endregion

        #region Static Methods

        public static IList<MasterCategory> FindWithPage(string keyword, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword, page);
        }
       

        public static IList<MasterCategory> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<MasterCategory> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<MasterCategory> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static MasterCategory FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IMasterCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

