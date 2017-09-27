using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;
using MSNet.Common;
using MSNet.Common.DataRepositories;
using MSNet.Repair;
namespace MSNet.Repair.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RepairOrdersRepository : SimpleRepositoryBase<RepairOrders, long>, IRepairOrdersRepository 
    {
        public IList<RepairOrders> FindWithPage(string keyword, long CategoryId, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithPage");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);
            sqlParams.Add("CategoryId", CategoryId);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<RepairOrders> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }

    }    

    
}

