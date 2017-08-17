using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.BaseCategory;
using MSNet.Common.Articles.DataRepositories;
namespace MSNet.Common.Articles
{
    /// <summary>
    /// ArticleCategory
    /// </summary>
    public class ArticlesCategory : BaseCategory<long>
    {

        //private static IArticlesCategoryRepository repository = new BaseRepositoryFactory().GetRepository<ArticlesCategoryRepository>();

        #region Instance Properties     
          
        public long CategoryId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
     
        public int Sort { get; set; }           
  		       
        #endregion

        #region Static Methods
        public static IList<ArticlesCategory> FindWithAll()
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.LoadAll();           
        }
        public static IList<ArticlesCategory> FindRoot()
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindRoot();
        }
        public static IList<ArticlesCategory> FindByParentId(long parentId)
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindByParentId(parentId);
        }
        public static ArticlesCategory FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

        public static int ExistChildCategory(long categoryId)
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.ExistChildCategory(categoryId);
        }

        public static bool Move(long categoryId, long parentId)
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Move(categoryId, parentId);
        }
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IArticlesCategoryRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

