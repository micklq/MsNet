using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using M2SA.AppGenome.Reflection;
using M2SA.AppGenome.Data;
using M2SA.AppGenome;
using System.Text.RegularExpressions;
using MSNet.Common.DataRepositories;
using MSNet.Common.Web;
using MSNet.Common;
using MSNet.Common.Util;
namespace MSNet.Tests
{
    public class NetArticlesTest : TestBase
    {
        #region ArticlesCategory Test

        [Test]
        public void ArticlesCategoryTest()
        {
            //添加             
            for (var i = 0; i < 5; i++)
            {  //创建Category
                var category = new ArticlesCategory() { Name = "Name" + i, Description = "Description" + i, ParentId = 0, Sort = i,  CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
                var result = category.Save();
                Assert.IsTrue(result);
                for (var j = 0; j < 3; j++)
                {
                    var result1 = new ArticlesCategory() { Name = "Name" + i, Description = "Description" + i, ParentId = category.CategoryId, Sort = i, CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now }.Save();
                    Assert.IsTrue(result1);
                }
            }
            //FindWithAll
            var list = ArticlesCategory.FindWithAll();
            long pid = 0;
            long cid = 0;
            foreach(var o in list){
                if (pid == 0 && o.ParentId > 0)
                {
                    pid = o.ParentId;
                }
                if (cid == 0 && o.ParentId > 0)
                {
                    cid = o.CategoryId;
                }
                Console.WriteLine("all==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            }
            //FindById
            var p = ArticlesCategory.FindById(pid);
             Assert.IsNotNull(p);
             Console.WriteLine(p.ToJson());
            //Save
             p.Name = "UpdateName";
             p.LastModifiedTime = DateTime.Now;
             p.PersistentState = PersistentState.Persistent;
             p.Save();
            //FindRoot
             var roots = ArticlesCategory.FindRoot();  
            foreach(var o in roots){
                Console.WriteLine("root==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            }
          
            //FindByParentId
            var parents = ArticlesCategory.FindByParentId(pid);
            foreach (var o in parents)
            {
                Console.WriteLine("parent==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            }

            ////ExistSonCategory
            var exits = ArticlesCategory.ExistChildCategory(pid);
            Console.WriteLine("existson==>>" + exits);
            //Move
            Console.WriteLine("Move==>>" + cid);
            Assert.IsTrue(ArticlesCategory.Move(cid, 0));
        }
        #endregion

        #region Articles Test
        [Test]
        public void ArticlesTest()
        {
            //添加             
            //for (var i = 0; i < 5; i++)
            //{  //创建Articles
            //    var category = new Articles() { Title = "TitleName" + i, Editor = "Editor" + i, CategoryId = 1, Media = "Media" + i, Description = "Description" + i, Contents = "Contents" + i, IsTop = (i % 2 == 0 ? 0 : 1), CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
            //    var result = category.Save();
            //    Assert.IsTrue(result);
            //}
            //FindWithAll
            //var list = Articles.FindWithAll();
            //long id = 0;
            //foreach (var o in list)
            //{
            //    if (id == 0)
            //    {
            //        id = o.ArticlesId;
            //    }
            //    Console.WriteLine("Articles All==>>Id:" + o.ArticlesId + "==>>Title:" + o.Title + "==>>CategoryId:" + o.CategoryId);
            //}
            //FindById
            //var p = Articles.FindById(id);
            //Assert.IsNotNull(p);
            //Console.WriteLine(p.ToJson());
            ////Save
            //p.Title = "ArticlesTitle";
            //p.LastModifiedTime = DateTime.Now;
            //p.PersistentState = PersistentState.Persistent;
            //p.Save();
            //FindRoot
            Pagination  p1 = new Pagination { PageIndex=1, PageSize=15 };
            Pagination  p2 = new Pagination { PageIndex=2, PageSize=5 };
            //var page1 = Articles.FindWithPage(p1);
            //foreach (var o in page1)
            //{
            //    Console.WriteLine("Articles Page1==>>Id:" + o.ArticlesId + "==>>Title:" + o.Title + "==>>CategoryId:" + o.CategoryId);
            //}
            //var page2 = Articles.FindWithPage(p2);
            //foreach (var o in page2)
            //{
            //    Console.WriteLine("Articles Page2==>>Id:" + o.ArticlesId + "==>>Title:" + o.Title + "==>>CategoryId:" + o.CategoryId);
            //}

            //FindByKeyword
            //var pkeys1 = Articles.FindByKeyword("", 2, p1);
            //long id = 0;
            //foreach (var o in pkeys1)
            //{
            //    if (id == 0) {
            //        id = o.ArticleId;
            //    }
            //    Console.WriteLine("Articles keyword1==>>id:" + o.ArticleId + "==>>title:" + o.Title + "==>>CategoryId:" + o.CategoryId);
            //}
         
            //Remove
            //Console.WriteLine("Remove==>>" + id);
            //Assert.IsTrue(new Articles() { ArticleId = id }.Remove());
        }
        
        #endregion



    }
}
