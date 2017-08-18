using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MSNet.Common.Web
{
    public class AjaxResult
    {
        public bool success { get; set; }
        public string message { get; set; }

        public string code { get; set; }

        public static AjaxResult Success(String message=""){
            return new AjaxResult() {success= true,message = message };             
        }
        public static AjaxResult Fail(String message)
        {
            return new AjaxResult() { success = false, message = message };    
        }        

    }
}
