using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class FeedbackRepository : SimpleRepositoryBase<Feedback, long>, IFeedbackRepository
    {
        public IList<Feedback> FindWithPage(string keyword, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithPage");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);        
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<Feedback> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }
        
    }    

    
}

