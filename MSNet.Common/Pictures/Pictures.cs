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
    /// Role
    /// </summary>
    public class Pictures : EntityBase<long>
    {
        #region Instance Properties 
       
        public long PictureId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }      
        public long CategoryId { get; set; }
        public string Title { get; set; }       
        public string Description { get; set; }
 
        
        public string ImageUrl { get; set; }
        public int BrowseTimes { get; set; }         
  		       
        #endregion

        #region Extends Properties
        public string CategoryName
        {
            get;
            set;
        }
        #endregion

        #region Static Methods
        public static IList<Pictures> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }      

        public static IList<Pictures> FindWithPage(string keyword, long CategoryId, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword, CategoryId, page);
        }

        public static IList<Pictures> FindByCategoryId(long CategoryId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByCategoryId(CategoryId);
        }

        public static Pictures FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);           
        }

        public static bool UpdateCategoryId(long oCategoryId, long nCategoryId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.UpdateCategoryId(oCategoryId, nCategoryId);
        }

        public static bool UpdateBrowse(long ArticleId)
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.UpdateBrowse(ArticleId);
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);

        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IPicturesRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

    }
}

