using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;


namespace MSNet.Common.DataRepositories
{
    public interface IUserRolePermissionRepository : IRepository<UserRolePermission, long>
    {
        
        IList<UserRolePermission> FindByRoleId(long roleId);

        bool PermissionValueExist(long roleId, long permissionId, int permissionValue);
        bool RolePermissionExist(long roleId, long parentPermissionId);

        /// <summary>
        /// ��Ȩ��Idɾ��
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        bool RemoveByPermissionId(long permissionId);
        /// <summary>
        /// ����ɫIdɾ��
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool RemoveByRoleId(long roleId);

        bool UpdateParentPermissionId(long permissionId, long parentPermissionId);

        bool Insert(UserRolePermission model);

    }
}
 

