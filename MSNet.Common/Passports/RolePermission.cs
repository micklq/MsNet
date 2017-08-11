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
    /// RolePermission
    /// </summary>
    public class RolePermission : EntityBase<long>
    {
        #region Instance Properties        
        public long RoleId { get; set; } 
        public long PermissionId { get; set; }

        public long ParentPermId { get; set; }
        /// <summary>
        /// ��Ȩ��=1  ��дȨ��=1+3=4  ��дɾȨ��=1+3+5=9  ��ɾȨ��=1+5=6
        /// </summary>
        public long PermissionLevel { get; set; }

        #endregion
        

        #region Static Methods          

        public static bool PermissionLevelExist(long roleId, long permissionId, long permissionLevel)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.PermissionLevelExist(roleId, permissionId, permissionLevel);
            return results;
        }

        public static bool RolePermissionExist(long roleId, long parentPermId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.RolePermissionExist(roleId, parentPermId);
            return results;
        }


        public static IList<RolePermission> FindByRoleId(long roleId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.FindByRoleId(roleId);
            return results;
        }
        /// <summary>
        /// ɾ��Ȩ���½�ɫ
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public static bool RemoveByPermissionId(long permissionId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.RemoveByPermissionId(permissionId); ;
        }
        /// <summary>
        /// ɾ����ɫ�µ�Ȩ��
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool RemoveByRoleId(long roleId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.RemoveByRoleId(roleId); ;
        }
        #endregion

        #region Persist Methods
        public bool Save()
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);            
            return repository.Insert(this);
          
        }      
        #endregion

    }
}

