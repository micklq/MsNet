using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    public interface IMasterCategoryRepository : IBaseCategoryRepository<MasterCategory, long>  
    {
        IList<MasterCategory> FindWithPage(string keyword, Pagination page);
   
    }
}
 

