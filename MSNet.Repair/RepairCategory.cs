using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common;
using MSNet.Repair.DataRepositories;
namespace MSNet.Repair
{
    /// <summary>
    /// ArticleCategory
    /// </summary>
    public class RepairCategory : BaseCategory<long>
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
        public string ParentName
        {
            get;
            set;
        }
        #endregion

        #region Static Methods
        public static IList<RepairCategory> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<RepairCategory> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<RepairCategory> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static RepairCategory FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }

        public static IList<RepairCategory> GetBreadList(long pid, IList<RepairCategory> list)
        {
            IList<RepairCategory> bread = new List<RepairCategory>();
            getCategoryRecursion(pid, list, bread);
            return bread.OrderBy(o => o.ParentId).ToList();
        }

        public static void getCategoryRecursion(long pid, IList<RepairCategory> list, IList<RepairCategory> bread)
        {
            var oo = list.Where(o => o.CategoryId == pid).FirstOrDefault();
            if (pid != 0 && oo != null)
            {
                bread.Add(oo);
                getCategoryRecursion(oo.ParentId, list,bread);
            }
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IRepairCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

