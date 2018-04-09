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
using MSNet.Common;
using MSNet.Common.Web;
using MSNet.Common.Util;
namespace MSNet.Tests
{
    public class NetPassportsTest : TestBase
    {
        #region User Test
        [Test]
        public void SignUpTest()
        {

            SignedUpInfo signedUpInfo = new SignedUpInfo() { SignedUpTime = DateTime.Now, SignedUpIp = "127.0.0.1", HttpUserAgent = "nunit.framework.test" };
            UserPassport uPassport = new UserPassport() { UserName = "admin", Password = "654321", Mobile="13683205268",  RoleType = UserRoleType.Adminstrator, RoleId=1 };
            UserPassport status = null ;
            var result = MemberShip.Add(uPassport, signedUpInfo, out status);    

            //var result = MemberShip.SignUp("13683205266","123456", signedUpInfo, out status);    
            Assert.IsTrue(result.success);
            Console.WriteLine(status.ToJson());
        }
        [Test]
        public void SignInTest()
        {
           
                UserPassport uPassport = null;
                var result = MemberShip.SignIn("13683205266", "123456", out uPassport);
                Console.WriteLine(result.ToJson());
                Assert.IsTrue(result.success);
                Console.WriteLine(uPassport.ToJson());            
           
           
           
        }

        [Test]
        public void UserPassportAdminPageTest()
        {

            var result = UserPassport.FindWithAdminPage("",1, new List<long> { 0 }, new Pagination { PageIndex=1, PageSize=10 });
            Assert.IsNotNull(result);
            if (result.Count>0)
            {
                foreach (var o in result) {                   
                    Console.WriteLine(o.ToJson());
                }
                
            }
        }


        [Test]
        public void WebAppLogsTest()
        {
            //for (var i = 1; i < 10; i++)
            //{
            //    Systemlogs logs = new Systemlogs() { PassportId = i, UserName = "UserName" + i, UserAction = "UserAction" + i, ClientIp = "127.0.0.1", HttpUserAgent = "nunit.framework.test", RefererDomain = "nunit.framework.test" };
            //    logs.Insert();
            //}
            Pagination p1 = new Pagination { PageIndex = 1, PageSize = 10 };
            var logss = WebAppLogs.FindWithPage("", "", "", p1);
            foreach (var o in logss)
            {
                Console.WriteLine("logs==>>" + o.LogsId + ":" + o.UserName + ":" + o.UserAction);
            }          
            

            
        }

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
