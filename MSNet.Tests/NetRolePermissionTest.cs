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
namespace MSNet.Tests
{
    public class NetRolePermissionTest : TestBase
    {
        #region User Test

        [Test]
        public void PermissionTest()
        {
            //添加             
            //for (var i = 0; i < 5; i++) {  //创建权限
            //    var permission = new Permission() { Name = "Name" + i, Description = "Description" + i, ParentId = 0, Sort = i, Value = "test", CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now };
            //     var result =  permission.Save();
            //    Assert.IsTrue(result);
            //    for (var j = 0; j < 3; j++) {
            //       var result1 =  new Permission() { Name = "Name" + i, Description = "Description" + i, ParentId = permission.PermissionId, Sort = i, Value = "test", CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now }.Save();
            //         Assert.IsTrue(result1);
            //    }
            //}
            //FindWithAll
            var list =  Permission.FindWithAll();
            //long id = 0;
            foreach(var o in list){
            //    if(id==0){
            //      id = o.PermissionId;
            //    }
             Console.WriteLine("all==>>"+o.PermissionId + ":"+o.Name +":" + o.ParentId);
            }
            //FindById
            // var p =  Permission.FindById(1);
            // Assert.IsNotNull(p);
            // Console.WriteLine(p.ToJson());
            ////Save
            // p.Name="UpdateName";
            // p.LastModifiedTime = DateTime.Now;
            // p.PersistentState = PersistentState.Persistent;
            // p.Save();
            //FindRoot
            //var roots =  Permission.FindRoot();    
            ////long pid = 10;
            //foreach(var o in roots){                  
            // Console.WriteLine("root==>>"+o.PermissionId + ":"+o.Name +":" + o.ParentId);
            //}
          
            //FindByParentId
            //var parents =  Permission.FindByParentId(10);
            //foreach (var o in parents)
            //{                 
            // Console.WriteLine("parent==>>"+o.PermissionId + ":"+o.Name +":" + o.ParentId);
            //}

            ////ExistSonCategory
            //var exits = Permission.ExistChildCategory(10);
            //Console.WriteLine("existson==>>" + exits);
            //Move
           // Assert.IsTrue(Permission.Move(11,12));
        }

        [Test]
        public void RoleProcessTest()
        {
            //for (var i = 0; i < 5; i++) {  //创建权限
            //    var result = new Permission() { Name = "Name" + i, Description = "Description" +i, Pid=0,Sort=i,Value="test" ,CreatedTime =DateTime.Now,LastModifiedTime=DateTime.Now }.Save();
            //    Assert.IsTrue(result);
            //}
            //for (var i = 0; i < 5; i++){ //创建角色

            //    var result = new Role() { Name = "Name" + i, Description = "Description" + i, RoleType = 1, CreatedTime = DateTime.Now, LastModifiedTime = DateTime.Now }.Save();
            //    Assert.IsTrue(result);
            //}            
            //角色权限
            IList<Permission> permissions = Permission.FindWithAll();
            IList<Role> roles = Role.FindWithAll();
            //if (permissions != null && permissions.Count > 0 && roles != null && roles.Count > 0)
            //{
            //    foreach (var o in permissions)
            //    {
            //        Console.WriteLine(o.PermissionId);
            //         //插入角色权限
            //        foreach (var oo in roles)
            //        {
            //            Assert.IsTrue(new RolePermission() { PermissionId = o.Id, RoleId = oo.Id, PermissionLevel = 1 }.Save());
            //        }
            //    }
            //}

            //用户角色
            //if (roles != null && roles.Count > 0)
            //{
            //    if (roles.FirstOrDefault() != null)
            //    {
            //        Assert.IsTrue(new UserRole() { PassportId = 1, RoleId = roles.FirstOrDefault().Id }.Save());
            //    }
            //}
        }

        [Test]
        public void RoleDelTest()
        {
            new Role() { RoleId=2 }.Remove();           
        }

        [Test]
        public void PermissionDelTest()
        {
            if (Permission.ExistChildCategory(11) == 0)
            {
                new Permission() { PermissionId = 11 }.Remove();
            }
            else {
                Console.WriteLine("exist Child node");
            
            }
           
        }
        #endregion



    }
}
