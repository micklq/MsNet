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
    public class RepairOrders : EntityBase<long>
    {
               

        #region Instance Properties    
        public long OrderId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }  
          
        public String CategoryIds{ get; set; }

        public String CategoryNames { get; set; } 

        public string FaultDescription { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        /// <summary>
        /// ����λ��γ��
        /// </summary>
        public string Latitude  { get; set; }
        /// <summary>
        /// ����λ�þ���
        /// </summary>
        public string Longitude  { get; set; }
        /// <summary>
        /// ����λ�þ���
        /// </summary>
        public string Precision { get; set; } 
        #endregion

        #region Extends Properties
       
        #endregion

        #region Static Methods       
       
        public static RepairOrders FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IRepairOrdersRepository>(ModuleEnvironment.ModuleName);
            return repository.FindById(Id);            
        }

      
        #endregion

        #region Persist Methods

        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IRepairOrdersRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IRepairOrdersRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);
        }
        #endregion

    }
}

