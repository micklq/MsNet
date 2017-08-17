using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;

namespace MSNet.Common.Articles.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticlesRepository : SimpleRepositoryBase<Articles, long>, IArticlesRepository
    {
        public IList<Articles> FindWithPage(Pagination page)
        {
            var sqlName = this.FormatSqlName("SelectWithPage");                  
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, null, page);
            IList<Articles> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }

        public IList<Articles> FindByKeyword(string keyword, long CategoryId, Pagination page)
        {
            var sqlName = this.FormatSqlName("SelectByKeyword");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", keyword);            
            sqlParams.Add("CategoryId", CategoryId);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<Articles> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }

        public bool UpdateCategoryId(long oCategoryId, long nCategoryId)
        {
            var sqlName = this.FormatSqlName("UpdateCategoryId");
            var pValues = new Dictionary<string, object>(2);
            pValues.Add("oCategoryId", oCategoryId);
            pValues.Add("nCategoryId", nCategoryId);
            return SqlHelper.ExecuteNonQuery(sqlName, pValues) > 0;

        }
    }    

    
}

