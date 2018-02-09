using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;

namespace MSNet.Common.DataRepositories
{
    public interface IPicturesRepository : IRepository<Pictures, long>
    {
        IList<Pictures> FindWithPage(string keyword, long CategoryId, Pagination page);

        IList<Pictures> FindByCategoryId(long CategoryId);

        bool UpdateCategoryId(long oCategoryId, long nCategoryId);

        bool UpdateBrowse(long PictureId);

        bool RemoveByCategoryId(long categoryId);
    }
}
 

