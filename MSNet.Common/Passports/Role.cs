using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Passports.DataRepositories;
namespace MSNet.Common.Passports
{
    /// <summary>
    /// Role
    /// </summary>
    public class Role : EntityBase<long>
    {
        #region Instance Properties 
       
        public long RoleId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        public string Name { get; set; } 
        public string Description { get; set; } 
        /// <summary>
        /// ϵͳ����Ա1  ��ͨ�û�0
        /// </summary>
        public int RoleType { get; set; }          
  		       
        #endregion

        public string RolePermissions { get; set; } 

        #region Static Methods
        public static IList<Role> FindWithAll()
        {
            
            var repository = RepositoryManager.GetRepository<IRoleRepository>(ModuleEnvironment.ModuleName);
            var results = repository.LoadAll();
            return results;
        }
        

        public static Role FindById(long Id)
        {
            var repository = RepositoryManager.GetRepository<IRoleRepository>(ModuleEnvironment.ModuleName);
            var result = repository.FindById(Id);
            return result;
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IRoleRepository>(ModuleEnvironment.ModuleName);
            return repository.Save(this);
          
        }
        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IRoleRepository>(ModuleEnvironment.ModuleName);
            bool result=repository.Remove(this);

            //���µ�ǰ��ɫ�µ��û�Ϊ�޽�ɫ�� 0
            result = result && (UserPassport.ClearRole(this.RoleId));
            //ɾ����ɫ�µ�Ȩ��
            result = result && (RolePermission.RemoveByRoleId(this.RoleId));
            return result;

        }
        #endregion

    }
}

