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
    /// PictureCategory
    /// </summary>
    public class PicturesCategory : BaseCategory<long>
    {
        #region Instance Properties     
          
        public long CategoryId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
     
        public int Sort { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateTime PublicDate { get; set; }

        #endregion

        #region Extends Properties
        public string ImageUrls
        {
            get;
            set;
        }
        #endregion

        #region Static Methods

        public static IList<PicturesCategory> FindWithPage(string keyword, int year, int month, int day, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword, year, month, day, page);
        }

        public static PicturesCategory FindByPublicDate(int year, int month, int day)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByPublicDate(year, month, day);
        }

        public static IList<PicturesCategory> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<PicturesCategory> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<PicturesCategory> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static PicturesCategory FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IPicturesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

