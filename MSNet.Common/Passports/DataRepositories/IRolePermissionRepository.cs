using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;


namespace MSNet.Common.Passports.DataRepositories
{
    public interface IRolePermissionRepository : IRepository<RolePermission, long>
    {
        
        IList<RolePermission> FindByRoleId(long roleId);
        
        /// <summary>
        /// 按权限Id删除
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        bool RemoveByPermissionId(long permissionId);
        /// <summary>
        /// 按角色Id删除
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool RemoveByRoleId(long roleId);

        bool Insert(RolePermission model);

    }
}
 

