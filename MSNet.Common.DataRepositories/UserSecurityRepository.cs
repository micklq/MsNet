using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using MSNet.Common;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserSecurityRepository : SimpleRepositoryBase<UserSecurity, long>, IUserSecurityRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Save(UserSecurity model)
        {
            ArgumentAssertion.IsNotNull(model, "model");

            var result = base.Save(model);

            return result;
        }
    }
}