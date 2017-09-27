using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M2SA.AppGenome.Data;
using MSNet.Common;

namespace MSNet.Repair.DataRepositories
{
    public interface IRepairOrdersRepository : IRepository<RepairOrders, long>
    {
        IList<RepairOrders> FindWithPage(string keyword, long CategoryId, Pagination page);
    }
}
