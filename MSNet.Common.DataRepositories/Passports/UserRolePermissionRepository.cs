using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using System.Collections;
using System.Collections.Generic;
using M2SA.AppGenome.Data.SqlMap;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRolePermissionRepository : SimpleRepositoryBase<UserRolePermission, long>, IUserRolePermissionRepository
    {
               
        public IList<UserRolePermission> FindByRoleId(long roleId)
        {
            var sqlName = this.FormatSqlName("SelectByRoleId");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("RoleId", roleId);
            var dataset = SqlHelper.ExecuteDataSet(sqlName, sqlParams);
            IList<UserRolePermission> model = null;
            if (dataset.Tables[0].Rows.Count > 0)
            {
                model = this.Convert(dataset.Tables[0]);
            }
            return model;
        }

        public bool PermissionValueExist(long roleId, long permissionId, int permissionValue)
        {
            var sqlName = this.FormatSqlName("PermissionValueExist");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("RoleId", roleId);
            pValues.Add("PermissionId", permissionId);
            pValues.Add("PermissionValue", permissionValue);
            var idValue = SqlHelper.ExecuteScalar(sqlName, pValues);
            return idValue.Convert<int>(0) > 0;
         
        }

        public bool RolePermissionExist(long roleId, long parentPermissionId)
        {
            var sqlName = this.FormatSqlName("RolePermissionExist");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("RoleId", roleId);
            pValues.Add("ParentPermissionId", parentPermissionId);
            var idValue = SqlHelper.ExecuteScalar(sqlName, pValues);
            return idValue.Convert<int>(0) > 0;
          
        }

        public bool Insert(UserRolePermission model)
        {
            model.PersistentState = PersistentState.Transient;
            return base.Save(model); 
        }

        public bool RemoveByRoleId(long roleId)
        {
            var sqlName = this.FormatSqlName("DeleteByRoleId");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("RoleId", roleId);
            return SqlHelper.ExecuteNonQuery(sqlName, pValues) > 0;
        }

        public bool RemoveByPermissionId(long permissionId)
        {
            var sqlName = this.FormatSqlName("DeleteByPermissionId");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("PermissionId", permissionId);
            return SqlHelper.ExecuteNonQuery(sqlName, pValues) > 0;
            
        }

        public bool UpdateParentPermissionId(long permissionId, long parentPermissionId)
        {
            var sqlName = this.FormatSqlName("UpdateParentPermissionId");
            var pValues = new Dictionary<string, object>(2);
            pValues.Add("PermissionId", permissionId);
            pValues.Add("ParentPermissionId", parentPermissionId);
            return SqlHelper.ExecuteNonQuery(sqlName, pValues) > 0;

        }
       

    }    

    
}

