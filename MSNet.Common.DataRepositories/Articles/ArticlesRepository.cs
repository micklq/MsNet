using M2SA.AppGenome.Data;
using System.Collections;
using System.Collections.Generic;

namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticlesRepository : SimpleRepositoryBase<Articles, long>, IArticlesRepository
    {       

        public IList<Articles> FindWithPage(string keyword, long CategoryId, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithPage");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);            
            sqlParams.Add("CategoryId", CategoryId);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<Articles> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }

        public IList<Articles> FindWithPage(long excludeCategoryId, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithExcludeCategoryId");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("CategoryId", excludeCategoryId);
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<Articles> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }
        public IList<Articles> FindWithAscPage(string keyword, long CategoryId, Pagination page)
        {
            var sqlName = this.FormatSqlName("FindWithAscPage");
            var sqlParams = new Dictionary<string, object>(3);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);
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

        public bool UpdateBrowse(long ArticleId)
        {
            var sqlName = this.FormatSqlName("UpdateBrowse");
            var pValues = new Dictionary<string, object>(1);
            pValues.Add("ArticleId", ArticleId);            
            return SqlHelper.ExecuteNonQuery(sqlName, pValues) > 0;
        }
    }    

    
}

