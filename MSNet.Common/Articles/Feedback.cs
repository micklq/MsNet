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
    /// Feedback
    /// </summary>
    public class Feedback : EntityBase<long>
    {
        #region Instance Properties        
        public long FeedbackId
        {
            get { return this.Id; }
            set { this.Id = value; }
        } 
        public string Contents { get; set; } 
        public string Email { get; set; } 
        public string Mobile { get; set; } 
      
  		       
        #endregion

        #region Static Methods
        public static IList<Feedback> FindWithAll()
        {
            
            var repository = RepositoryManager.GetRepository<IFeedbackRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }
        public static Feedback FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IFeedbackRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }

        public static IList<Feedback> FindWithPage(string keyword, Pagination page)
        {
            var repository = RepositoryManager.GetRepository<IFeedbackRepository>(ModuleEnvironment.ModuleName);
            return repository.FindWithPage(keyword,page);
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IFeedbackRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IFeedbackRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

    }
}

