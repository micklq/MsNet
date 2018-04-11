using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    public interface IArticlesRepository : IRepository<Articles, long>
    {
        IList<Articles> FindWithPage(string keyword, long CategoryId, Pagination page);

        IList<Articles> FindWithPage(long CategoryId, Pagination page);

        IList<Articles> FindWithAscPage(string keyword, long CategoryId, Pagination page);

        bool UpdateCategoryId(long oCategoryId, long nCategoryId);

        bool UpdateBrowse(long ArticleId);
    }
}
 

