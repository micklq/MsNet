using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSNet.Common.Security;
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
       /// 角色Id
       /// </summary>
       public long RoleId { get; set; }
       /// <summary>
       /// 角色名称
       /// </summary>
       public string RoleName { get; set; }         
       /// <summary>
       /// 角色权限
       /// </summary>
       public IList<UserRolePermission> RolePermission { get; set; }
    }
}
