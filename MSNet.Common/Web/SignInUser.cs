using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSNet.Common.Passports;
namespace MSNet.Common.Web
{
   public  class SignInUser
   {
       /// <summary>
       /// 用户Id
       /// </summary>
       public long PassportId { get; set; }      
       /// <summary>
       /// 用户名
       /// </summary>
       public string UserName { get; set; }
       /// <summary>
       /// 用户角色
       /// </summary>
       public UserRole uRole { get; set; }
       /// <summary>
       /// 角色权限
       /// </summary>
       public IList<UserRolePermission> uPermissions { get; set; }
    }
}
