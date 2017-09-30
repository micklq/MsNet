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
    /// Joinedoperate
    /// </summary>
    public class JoinedOperate : EntityBase<long>
    {
        #region Instance Properties        
        public long JoinId
        {
            get { return this.Id; }
            set { this.Id = value; }
        } 
        public string FirmName { get; set; } 
        public string Contacts { get; set; } 
        public string TelPhone { get; set; } 
        public string Address { get; set; } 
        public string Zipcode { get; set; } 
      
        #endregion

        #region Static Methods
        public static IList<JoinedOperate> FindWithAll()
        {
            
            var repository = RepositoryManager.GetRepository<IJoinedOperateRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }
        public static JoinedOperate FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IJoinedOperateRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IJoinedOperateRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IJoinedOperateRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }
        #endregion

    }
}

