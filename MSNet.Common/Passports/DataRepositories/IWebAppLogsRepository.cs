using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    public interface IWebAppLogsRepository : IRepository<WebAppLogs, long>
    {
        IList<WebAppLogs> FindWithPage(string keyword, string beginTime, string endTime, Pagination page);
    }
}
 

