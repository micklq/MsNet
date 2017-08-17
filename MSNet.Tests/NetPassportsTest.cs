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
using MSNet.Common.Passports;
using MSNet.Common.Web;
using MSNet.Common.Util;
namespace MSNet.Tests
{
    public class NetPassportsTest : TestBase
    {
        #region User Test


        [Test]
        public void UserPassportAdminPageTest()
        {

            var result = UserPassport.FindWithAdminPage("", new List<long> { 0 }, new Pagination { PageIndex=1, PageSize=10 });
            Assert.IsNotNull(result);
            //if (result)
            {
                Console.WriteLine(result.ToJson());
            }
        }

        [Test]
        public void UserPassportTest()
        {

            var result = UserPassport.FindPassportIdByUserName("admin");
            Assert.IsNotNull(result);
            //if (result)
            {
                Console.WriteLine(result.ToJson());
            }
        }

        [Test]
        public void SignUpTest()
        {
            
            SignedUpInfo signedUpInfo=new SignedUpInfo() { SignedUpTime = DateTime.Now, SignedUpIp = "127.0.0.1", HttpUserAgent = "nunit.framework.test" };
            SignUpStatus status = SignUpStatus.None;
            var result = MemberShip.SignUp("admin1", "123456",signedUpInfo,out status);
            Assert.IsNotNull(result);            
        }

        public void SignedUpInfoTest()
        {

            var result = new SignedUpInfo() { PassportId = 1, SignedUpTime = DateTime.Now, SignedUpIp = "127.0.0.1",  HttpUserAgent = "nunit" }.Save();
            Assert.IsNotNull(result);           
            Console.WriteLine(result.ToJson());
           
        }

        //[Test]
        //public void SignInTest()
        //{
        //   var result= Users.SignIn("admin","123456".ToMD5());
        //   Assert.IsNotNull(result);
        //   if (result != null)
        //   {
        //       Console.WriteLine(result.ToJson());
        //   }
        //}
        //public void FindByUserIdTest()
        //{
        //    var result = Users.FindByUserId("DA8C8C9B-BDF8-45C5-9772-AF8151940A98".ToGuid());
        //    Assert.IsNotNull(result);
        //    if (result != null)
        //    {
        //        Console.WriteLine(result.ToJson());
        //    }
        //}

        //public void EditUserPasswordTest()
        //{
        //    var result = Users.FindByUserId("DA8C8C9B-BDF8-45C5-9772-AF8151940A98".ToGuid());
        //    Assert.IsNotNull(result);
        //    if (result != null)
        //    {
        //        Console.WriteLine(result.ToJson());
        //        result.Password = "123456".ToMD5();               
               
        //        //Console.WriteLine(result.Save());
        //    }
            
        //}

        //public void FindByIdTest()
        //{
        //    var result = Users.FindById(1);
        //    Assert.IsNotNull(result);
        //    if (result != null) {
        //        Console.WriteLine(result.ToJson());
        //    }
            
        //}

        //public void FindForPaginationTest()
        //{
        //    var page =new Pagination { PageIndex=1, PageSize=10 };
        //    var result = Users.FindForPagination(new List<int> { 1 }, page);
        //    Assert.IsNotNull(result);
        //    if (result != null)
        //    {
        //        Console.WriteLine(page.ToJson());
        //        Console.WriteLine(result.ToJson());
        //    }

        //}
        //public void SaveTest()
        //{
        //    for (var i = 0; i < 25; i++)
        //    {

        //        var u = new Users { UserId = Guid.NewGuid(), UserName = "test"+(i+10), Password = "123456".ToMD5(), GroupId = "CA0D94E3-A1E2-4858-ACDE-A6021F062077".ToGuid(), CreatedTime = DateTime.Now, LastModifyTime = DateTime.Now };
        //        var result = u.Save();
        //        Assert.IsTrue(result);
        //        if (result)
        //        {
        //            Console.WriteLine(u.ToJson());
        //            //u.LastModifyTime = DateTime.Now.AddDays(1);
        //            // u.Save();
        //        }     
        //    }
                  
        //}

        //public void RemoveTest()
        //{
        //    var u = new Users {  PassportId=40 };
        //    var result = u.Remove();
        //    Assert.IsTrue(result);
        //    Console.WriteLine(result);
        //}

        #endregion

        #region UserGroup Test
        //public void UserGroupFindByIdTest()
        //{
        //    var result = UserGroup.FindById("CA0D94E3-A1E2-4858-ACDE-A6021F062077".ToGuid());
        //    Assert.IsNotNull(result);
        //    if (result != null) {
        //        Console.WriteLine(result.ToJson());
        //    }
            
        //}

        //public void UserGroupFindWithAllTest()
        //{
        //    var result = UserGroup.FindWithAll();
        //    Assert.IsNotNull(result);
        //    if (result != null)
        //    {
        //        Console.WriteLine(result.ToJson());
        //    }
        //}
        //public void UserGroupSaveTest()
        //{
        //    var u = new UserGroup { GroupId = Guid.NewGuid(), GroupName = "管理员", GroupPermission = "***", GroupCreatedTime = DateTime.Now };            
        //    var result = u.Save();
        //    Assert.IsTrue(result);
        //    if (result)
        //    {
        //        Console.WriteLine(u.ToJson());
        //        //u.GroupStopTime = DateTime.Now.AddYears(1);
        //        //u.Save();
        //    }            
        //}

        //public void UserGroupRemoveTest()
        //{
        //    var u = new UserGroup { GroupId = "B76955E2-47BA-4CA0-98A9-9F5E29875EE7".ToGuid() };
        //    var result = u.Remove();
        //    Assert.IsTrue(result);
        //    Console.WriteLine(result);
        //}
        #endregion

        #region News Test
        //public void NewsFindForPaginationByWheres()
        //{
        //    var page = new Pagination { PageIndex = 1, PageSize = 10 };
        //    var result = News.FindForPagination("信托投资", 122,page);
        //    Assert.IsNotNull(result);
        //    if (result != null)
        //    {
        //        Console.WriteLine(page.ToJson());
        //        Console.WriteLine(result.ToJson());
        //    }

        //}
        #endregion


    }
}
