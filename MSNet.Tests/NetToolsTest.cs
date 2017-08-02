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
using MSNet.Common.Web;
using MSNet.Common.Web.Http;
using MSNet.Common.Util;
namespace MSNet.Tests
{
    public class NetToolsTest : TestBase
    {
               

        [Test]
        public void VerifyCodeTest()
        {
          // var result= VerifyCodeHelper.GenerateCode(4);
          // Console.WriteLine(result);
        }

        [Test]
        public void DtCompareTest()
        {
            var dt1 = DateTime.Now.AddMinutes(-10);
            var dt2 = DateTime.Now.AddMinutes(-8);
            var dt3 = DateTime.Now.AddMinutes(-13);
            Console.WriteLine(string.Format("dt1comparedt2:{0}",DateTime.Compare(dt1,dt2)));
            Console.WriteLine(string.Format("dt1comparedt3:{0}", DateTime.Compare(dt1, dt3)));     

        }

        [Test]
        public void ZipRAR()
        {
            string srcFile = @"G:\MyScoure\testzip\001.txt";//准备压缩的文件路径
            string zipFile = @"G:\MyScoure\testzip\001.txt";//压缩后的文件路径           
            Console.WriteLine("使用BZIP开始压缩文件……"); 
            if (ZipFile.BZipFile(srcFile, zipFile + ".zip"))//使用BZIP压缩文件             
            { 
                Console.WriteLine("文件压缩完成");            
            }

        }


      
    }
}
