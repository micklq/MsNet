using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.Articles.DataRepositories
{
    public interface IArticlesRepository : IRepository<Articles, long>
    {
        IList<Articles> FindWithPage(Pagination page);
        IList<Articles> FindByKeyword(string keyword, long CategoryId, Pagination page);
    }
}
 
