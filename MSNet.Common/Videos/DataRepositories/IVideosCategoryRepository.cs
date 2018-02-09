using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    public interface IVideosCategoryRepository : IBaseCategoryRepository<VideosCategory, long>  
    {
        IList<VideosCategory> FindWithPage(string keyword, Pagination page);
      
    }
}
 

