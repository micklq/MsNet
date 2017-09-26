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
using MSNet.Repair;
using MSNet.Repair.DataRepositories;

namespace MSNet.Tests
{
    public class NetArticlesTest : TestBase
    {
        #region ArticlesCategory Test

        [Test]
        public void ArticlesCategoryTest()
        {
            //添加             
            //for (var i = 0; i < 5; i++)
            {  //创建Category
                //var category = new ArticlesCategory() { Name = "Name" + i, Description = "Description" + i, ParentId = 0, Sort = i,  CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
                var category = new ArticlesCategory() { Name = "最新动态", Description = "最新动态", ParentId = 0, Sort = 1, CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
                var result = category.Save();
                Assert.IsTrue(result);
                //for (var j = 0; j < 3; j++)
                //{
                //    var result1 = new ArticlesCategory() { Name = "Name" + i, Description = "Description" + i, ParentId = category.CategoryId, Sort = i, CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now }.Save();
                //    Assert.IsTrue(result1);
                //}
            }
            //FindWithAll
            var list = ArticlesCategory.FindWithAll();
            //long pid = 0;
            //long cid = 0;
            foreach(var o in list){
                //if (pid == 0 && o.ParentId > 0)
                //{
                //    pid = o.ParentId;
                //}
                //if (cid == 0 && o.ParentId > 0)
                //{
                //    cid = o.CategoryId;
                //}
                Console.WriteLine("all==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            }
            //FindById
            //var p = ArticlesCategory.FindById(pid);
            // Assert.IsNotNull(p);
            // Console.WriteLine(p.ToJson());
            ////Save
            // p.Name = "UpdateName";
            // p.LastModifiedTime = DateTime.Now;
            // p.PersistentState = PersistentState.Persistent;
            // p.Save();
            ////FindRoot
            // var roots = ArticlesCategory.FindRoot();  
            //foreach(var o in roots){
            //    Console.WriteLine("root==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            //}
          
            ////FindByParentId
            //var parents = ArticlesCategory.FindByParentId(pid);
            //foreach (var o in parents)
            //{
            //    Console.WriteLine("parent==>>" + o.CategoryId + ":" + o.Name + ":" + o.ParentId);
            //}

            //////ExistSonCategory
            //var exits = ArticlesCategory.ExistChildCategory(pid);
            //Console.WriteLine("existson==>>" + exits);
            ////Move
            //Console.WriteLine("Move==>>" + cid);
            //Assert.IsTrue(ArticlesCategory.Move(cid, 0));
        }
        #endregion

        #region Articles Test
        [Test]
        public void ArticlesTest()
        {
            //添加             
            //for (var i = 0; i < 5; i++)
            //{  //创建Articles
            //    var article = new Articles() { Title = "资讯标题" + i, Editor = "资讯作者" + i, CategoryId = 1, Media = "资讯来源" + i, Description = "资讯简介" + i, Contents = "资讯内容" + i, CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
            //    var result = article.Save();
            //    Assert.IsTrue(result);
            //}

            //Articles.UpdateBrowse(1);

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
            Pagination  p1 = new Pagination { PageIndex=1, PageSize=5 };
            Pagination  p2 = new Pagination { PageIndex=2, PageSize=5 };        

            //FindWithPage
            //var pkeys1 = Articles.FindWithPage("", 1, p1);
            ////long id = 0;
            //foreach (var o in pkeys1)
            //{
            //    //if (id == 0) {
            //    //    id = o.ArticleId;
            //    //}
            //    Console.WriteLine("Articles keyword1==>>id:" + o.ArticleId + "==>>title:" + o.Title + "==>>CategoryId:" + o.CategoryId + "==>>CategoryName:" + o.CategoryName);
            //}
         
            //Remove
            //Console.WriteLine("Remove==>>" + id);
            //Assert.IsTrue(new Articles() { ArticleId = id }.Remove());
        }
        
        #endregion

        #region RepairCategory Test
        [Test]
        public void RepairCategoryTest()
        {
            var list = RepairCategory.FindWithAll();

            var result = GetBreadList(17,list);
            foreach (var oo in result) {
                Console.WriteLine(oo.Id);
            }
        }
        public IList<RepairCategory> GetBreadList(long pid, IList<RepairCategory> list)
        {
            IList<RepairCategory> bread = new List<RepairCategory>();
            getCategoryRecursion(pid, list, bread);
            return bread.OrderBy(o => o.ParentId).ToList();
        }

        public void getCategoryRecursion(long pid, IList<RepairCategory> list, IList<RepairCategory> bread)
        {
            var oo = list.Where(o => o.CategoryId == pid).FirstOrDefault();
            if (pid != 0 && oo != null)
            {
                bread.Add(oo);
                getCategoryRecursion(oo.ParentId, list, bread);
            }
        }
        #endregion

    }
}
