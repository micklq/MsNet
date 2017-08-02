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

        bool Insert(RolePermission model);

    }
}
 

