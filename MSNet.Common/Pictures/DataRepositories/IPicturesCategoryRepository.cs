using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome.Data;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    public interface IPicturesCategoryRepository : IBaseCategoryRepository<PicturesCategory, long>  
    {
        IList<PicturesCategory> FindWithPage(string keyword, int year, int month, int day, Pagination page);
        PicturesCategory FindByPublicDate(int year, int month, int day);
    }
}
 

