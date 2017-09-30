using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Joined.DataRepositories;
namespace MSNet.Joined
{
    /// <summary>
    /// Joinedarticles
    /// </summary>
    public class JoinedArticles : EntityBase<long>
    {
        #region Instance Properties        
        public long ArticleId
        {
            get { return this.Id; }
            set { this.Id = value; }
        } 
        public string Title { get; set; } 
        public string Keywords { get; set; } 
        public string Description { get; set; } 
        public string Contents { get; set; } 
        public int? BrowseTimes { get; set; } 
        public DateTime? CreatedTime { get; set; } 
        public DateTime? LastModifiedTime { get; set; } 
  		       
        #endregion

        #region Static Methods
        public static IList<JoinedArticles> FindWithAll()
        {
            
            var repository = RepositoryManager.GetRepository<IJoinedArticlesRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }
        public static JoinedArticles FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IJoinedArticlesRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IJoinedArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IJoinedArticlesRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

    }
}

