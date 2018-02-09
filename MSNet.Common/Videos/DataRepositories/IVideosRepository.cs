using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    public interface IVideosRepository : IRepository<Videos, long>
    {
        IList<Videos> FindWithPage(string keyword, long CategoryId, Pagination page);

        IList<Videos> FindWithKeys(string keyword, long CategoryId);

        IList<Videos> FindByCategoryId(long CategoryId);

        bool UpdateCategoryId(long oCategoryId, long nCategoryId);

        bool RemoveByCategoryId(long categoryId);
    }
}
 

