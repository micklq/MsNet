using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Data.SqlMap;
using M2SA.AppGenome.Reflection;

namespace MSNet.Common.Data
{
    /// <summary>
    /// 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors")]
    public abstract class BaseCategoryRepository<T, TId> : SimpleRepositoryBase<T, TId>, IBaseCategoryRepository<T, TId> 
        where T : class, IEntity<TId>, new()
    { 
        public virtual IList<T> FindRoot()
        {
            var sqlName = this.FormatSqlName("SelectRoot");            
            var dataset = SqlHelper.ExecuteDataSet(sqlName, null);

            IList<T> list = null;
            var itemCount = dataset.Tables[0].Rows.Count;
            if (itemCount > 0)
            {
                list = new List<T>(itemCount);
                for (var i = 0; i < itemCount; i++)
                {
                    var item = this.Convert(dataset.Tables[0].Rows[i]); 
                    list.Add(item);
                }
            }
            return list;
        }

        public virtual IList<T> FindByParentId(TId parentId)
        {
            var sqlName = this.FormatSqlName("SelectByParentId");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("ParentId", parentId);
            var dataset = SqlHelper.ExecuteDataSet(sqlName, sqlParams);
            IList<T> list = null;
            var itemCount = dataset.Tables[0].Rows.Count;
            if (itemCount > 0)
            {
                list = new List<T>(itemCount);
                for (var i = 0; i < itemCount; i++)
                {
                    var item = this.Convert(dataset.Tables[0].Rows[i]); 
                    list.Add(item);
                }
            }
            return list;
        }

        public virtual int ExistChildCategory(TId parentId)
        {
            var sqlName = this.FormatSqlName("ExistChildCategory");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("ParentId", parentId);         
            var result = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return System.Convert.ToInt16(result);           
        }

        public virtual bool Move(TId categoryId, TId parentId)
        {
            var sqlName = this.FormatSqlName("Move");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("CategoryId", categoryId);
            pValues.Add("ParentId", parentId);
            var rowsAffected = SqlHelper.ExecuteNonQuery(sqlName, pValues);

            var result = rowsAffected > 0;
            return result;
        }

        
    }    

    
}

