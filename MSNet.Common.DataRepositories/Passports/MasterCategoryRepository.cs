using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MasterCategoryRepository : BaseCategoryRepository<MasterCategory, long>, IMasterCategoryRepository   
    {
        public IList<MasterCategory> FindWithPage(string keyword, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithPage");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);           
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<MasterCategory> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }       
       
    }    

    
}

