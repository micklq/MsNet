using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class PicturesCategoryRepository : BaseCategoryRepository<PicturesCategory, long>, IPicturesCategoryRepository   
    {
        public IList<PicturesCategory> FindWithPage(string keyword, int year, int month, int day, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithPage");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);
            sqlParams.Add("Year", year);
            sqlParams.Add("Month", month);
            sqlParams.Add("Day", day);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<PicturesCategory> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }
       
    }    

    
}

