using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using System.Collections;
using System.Collections.Generic;
using M2SA.AppGenome.Data.SqlMap;

namespace MSNet.Common.Passports.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePermissionRepository : SimpleRepositoryBase<RolePermission, long>, IRolePermissionRepository
    {
               
        public IList<RolePermission> FindByRoleId(long roleId)
        {
            var sqlName = this.FormatSqlName("SelectByRoleId");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("RoleId", roleId);
            var dataset = SqlHelper.ExecuteDataSet(sqlName, sqlParams);

            IList<RolePermission> list = null;
            var itemCount = dataset.Tables[0].Rows.Count;
            if (itemCount > 0)
            {
                list = new List<RolePermission>(itemCount);
                for (var i = 0; i < itemCount; i++)
                {
                    var item = this.Convert(dataset.Tables[0].Rows[i]);
                    list.Add(item);
                }
            }
            return list;
        }
        public bool Insert(RolePermission model)
        {
            var result = false;

            var sqlName = this.FormatSqlName("Insert");
            var pValues = model.ToDictionary(); 
            var rowsAffected = SqlHelper.ExecuteNonQuery(sqlName, pValues);
            result = rowsAffected > 0;   
            return result;
        }



        public bool RemoveByPermissionId(long permissionId)
        {
            var sqlName = this.FormatSqlName("DeleteByPermissionId");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("PermissionId", permissionId);
            var rowsAffected = SqlHelper.ExecuteNonQuery(sqlName, pValues);            

            var result = rowsAffected > 0;
            return result;
        }
        public bool RemoveByRoleId(long roleId)
        {
            var sqlName = this.FormatSqlName("DeleteByRoleId");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("RoleId", roleId);
            var rowsAffected = SqlHelper.ExecuteNonQuery(sqlName, pValues);

            var result = rowsAffected > 0;
            return result;
        }

    }    

    
}

