using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
namespace MSNet.Common.Util
{
    public class ZipFile
    {
        public static bool BZipFile(string sourcefilename, string zipfilename)
        { 
            bool blResult;//表示压缩是否成功的返回结果 
            //为源文件创建文件流实例，作为压缩方法的输入流参数             
             FileStream srcFile = File.OpenRead(sourcefilename); 
            //为压缩文件创建文件流实例，作为压缩方法的输出流参数             
             FileStream zipFile = File.Open(zipfilename, FileMode.Create);             
             try             
             { 
                //以4096字节作为一个块的方式压缩文件                 
                 BZip2.Compress(srcFile, zipFile, 4096);                 
                 blResult=true;            
             } 
            catch (Exception ee) 
            { 
                Console.WriteLine(ee.Message);                 blResult=false; 
            } 
            srcFile.Close();//关闭源文件流            
            zipFile.Close();//关闭压缩文件流            
            return blResult;
         }
    }
}
