using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemlogsRepository : SimpleRepositoryBase<Systemlogs, long>, ISystemlogsRepository
    {
        public IList<Systemlogs> FindWithPage(string keyword, string beginTime, string endTime, Pagination page)
        {
            var sqlName = this.FormatSqlName("SelectWithPage");

            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);
            sqlParams.Add("BeginTime", (string.IsNullOrEmpty(beginTime) || string.IsNullOrEmpty(endTime)) ? null : beginTime);
            sqlParams.Add("EndTime", (string.IsNullOrEmpty(beginTime) || string.IsNullOrEmpty(endTime)) ? null : endTime);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<Systemlogs> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }
    }    

    
}

