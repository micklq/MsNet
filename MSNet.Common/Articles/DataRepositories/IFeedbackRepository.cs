using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    public interface IFeedbackRepository : IRepository<Feedback, long>
    {
        IList<Feedback> FindWithPage(string keyword, Pagination page);
    }
}
 

