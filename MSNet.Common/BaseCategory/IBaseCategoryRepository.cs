using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Data.SqlMap;
using M2SA.AppGenome.Reflection;

namespace MSNet.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseCategoryRepository<T, TId> : IRepository<T, TId> where T : IEntity<TId>
    {
        IList<T> FindRoot();
        IList<T> FindByParentId(TId parentId); 
        int ExistChildCategory(TId parentId);       
        bool Move(TId categoryId, TId parentId);
        
    }    

    
}

