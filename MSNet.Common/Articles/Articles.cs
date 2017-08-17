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
    public class Articles : EntityBase<long>
    {
        #region Instance Properties 
       
        public long ArticleId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }      
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Editor { get; set; }
        public string Media { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public int IsTop { get; set; }        
  		       
        #endregion

        #region Static Methods
        public static IList<Articles> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<Articles> FindWithPage(Pagination page)
        {   
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(page);
        }

        public static IList<Articles> FindByKeyword(string keyword, long CategoryId, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByKeyword(keyword,CategoryId,page);
        }
        public static Articles FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);           
        }
        public static bool UpdateCategoryId(long oCategoryId, long nCategoryId)
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.UpdateCategoryId(oCategoryId, nCategoryId);
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);

        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

    }
}

