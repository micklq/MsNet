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
    /// RolePermission
    /// </summary>
    public class RolePermission : EntityBase<long>
    {
        #region Instance Properties        
        public long RoleId { get; set; } 
        public long PermissionId { get; set; }

        public long ParentPermissionId { get; set; }
        /// <summary>
        /// 添加=1  修改=2 删除=3 Read=4  读审删权限=1+3+7=11 读写删权限=1+5+7=13
        /// </summary>
        public long PermissionValue { get; set; }

        #endregion
        public RolePermission()
        {
            this.CreatedTime = DateTime.Now;
            this.LastModifiedTime = this.CreatedTime;
        }

        #region Static Methods   
       
        public static IList<RolePermission> FindByRoleId(long roleId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.FindByRoleId(roleId);
            return results;
        }

        /// <summary>
        /// 删除角色下的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static bool RemoveByRoleId(long roleId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.RemoveByRoleId(roleId); ;
        }

        public static bool PermissionValueExist(long roleId, long permissionId, int permissionValue)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.PermissionValueExist(roleId, permissionId, permissionValue);
            return results;
        }

        public static bool RolePermissionExist(long roleId, long parentPermissionId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            var results = repository.RolePermissionExist(roleId, parentPermissionId);
            return results;
        }


      
        /// <summary>
        /// 删除权限下角色
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public static bool RemoveByPermissionId(long permissionId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.RemoveByPermissionId(permissionId); ;
        }

        public static bool UpdateParentPermissionId(long permissionId, long parentPermissionId)
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.UpdateParentPermissionId(permissionId, parentPermissionId); ;
        }
        
        #endregion

        #region Persist Methods

        public bool Insert()
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return  repository.Insert(this);
          
        }

        public bool Remove()
        {
            var repository = RepositoryManager.GetRepository<IRolePermissionRepository>(ModuleEnvironment.ModuleName);
            return repository.Remove(this);

        }   
        #endregion

    }
}

