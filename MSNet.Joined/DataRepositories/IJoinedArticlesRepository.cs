using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Joined.DataRepositories
{
    public interface IJoinedArticlesRepository : IRepository<JoinedArticles, long>
    {
        IList<JoinedArticles> FindWithPage(string keyword, Pagination page);

        bool UpdateBrowse(long ArticleId);
    }
}
 

